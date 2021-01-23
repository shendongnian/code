    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string XMLText = File.ReadAllText(FILENAME);
                List<Rate> myRates = new List<Rate>(); 
                using (XmlReader reader = XmlReader.Create(new StringReader(XMLText)))
                {
                    while (!reader.EOF)
                    {
                        if (reader.Name != "rate")
                        {
                            reader.ReadToFollowing("rate");
                        }
                        if(!reader.EOF)
                        {
                            XElement xRate = (XElement)XElement.ReadFrom(reader);
                            Rate rate = new Rate();
                            rate.Category = xRate.Attribute("category").Value;  //text of current Node   : Catagory
                            DateTime myDate;
                            if (DateTime.TryParse(xRate.Attribute("date").Value, out myDate))
                            {
                                rate.Date = myDate;
                            }
                            Console.WriteLine("value Element=" + xRate.Element("value").Value); //test: reader.Value does not the data
                            decimal myValue;
                            if (Decimal.TryParse(xRate.Element("value").Value, out myValue))
                            {
                                rate.Value = myValue;
                            }
                            else
                            {
                                rate.Value = -1;   // this is what happens because reader.value == ""
                            }
                            //return collection with result
                            myRates.Add(rate);
                        }
                    }
                }
            }
            public class Rate
            {
                public DateTime Date { get; set; }
                public decimal Value { get; set; }
                public string Category { get; set; }
            }
        }
    }
