    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication37
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                "<item xmlns:dcterms=\"www.myspace.com\" xmlns:dc=\"www.myspace.com\" xmlns:itunes=\"www.myspace.com\">" +
                "<title>Episode 41 - Brobdingnagian Lunches To Die For</title>" +
                "<pubDate>Fri, 17 Jul 2015 13:00:00 GMT</pubDate>" +
                "<dcterms:modified>2015-07-17</dcterms:modified>" +
                "<dcterms:created>2015-07-17</dcterms:created>" +
                "<link>http://starttocontinue.podomatic.com</link>" +
                "<dc:creator>Start To Continue</dc:creator>" +
                "<itunes:duration>0</itunes:duration>" +
                "<itunes:explicit>yes</itunes:explicit>" +
                "<itunes:order>1</itunes:order>" +
                "</item>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("item").Select(x => new
                {
                    title = x.Element("title").Value,
                    pubDate = x.Element("pubDate").Value,
                    modified = x.Elements().Where(y => y.Name.LocalName == "modified").FirstOrDefault().Value,
                    created = x.Elements().Where(y => y.Name.LocalName == "created").FirstOrDefault().Value,
                    link = x.Element("link").Value,
                    creator = x.Elements().Where(y => y.Name.LocalName == "creator").FirstOrDefault().Value,
                    duration = x.Elements().Where(y => y.Name.LocalName == "duration").FirstOrDefault().Value,
                    explicit1 = x.Elements().Where(y => y.Name.LocalName == "explicit").FirstOrDefault().Value,
                    order = x.Elements().Where(y => y.Name.LocalName == "order").FirstOrDefault().Value,
                }).ToList();
            }
        }
    }
