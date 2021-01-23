    using System.Collections.Generic;
    using HtmlAgilityPack;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Linq;
    public class TheScraper
    {
        public List<Listing> DoTheScrape()
        {
            List<Listing> result = new List<Listing>();
            string url = "http://www.scoot.co.uk/find/" + "cafe" + " " + "-in-uk?page=" + "4";
            
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);
            // select top level node, this is the closest we can get to the elements in which all the listings are a child of.
            var nodes = doc.DocumentNode.SelectNodes("//*[@id='list']/div/div/div/div");
            // loop through each child 
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    Listing listing = new Listing();
                    // get each individual listing. the "?" operator will act like a null check, returning null instead of exceptions.
                    listing.Name = node.SelectSingleNode("./div/div/div/div/h2/a")?.InnerText;
                    listing.Address = node.SelectSingleNode("./div/div/div/div/p[@class='result-address']")?.InnerText.Trim();
                    listing.Number = listing.Number = node.SelectSingleNode("./div/div/div/div/p[@class='result-number']/a")?.Attributes["data-visible-number"].Value;
                    
                    result.Add(listing);
                }
            }
            // filter out the nulls
            result = result.Where(x => x.Name != null && x.Address != null && x.Number != null).ToList();
            return result;
        }
        public string SerializeTheListings(List<Listing> listings)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Listing>));
            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
            {
                xmlSerializer.Serialize(xmlWriter, listings);
                return stringWriter.ToString();
            }
        }
    }
