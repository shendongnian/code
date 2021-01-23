    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<string>" +
                     "<StockQuotes>" +
                       "<Stock>" +
                         "<Symbol>msft</Symbol>" +
                         "<Last>46.62</Last>" +
                         "<Date>7/17/2015</Date>" +
                         "<Time>4:00pm</Time>" +
                         "<Change>-0.04</Change>" +
                         "<Open>46.59</Open>" +
                         "<High>46.78</High>" +
                         "<Low>46.26</Low>" +
                         "<Volume>29467107</Volume>" +
                         "<MktCap>377.14B</MktCap>" +
                         "<PreviousClose>46.66</PreviousClose>" +
                         "<PercentageChange>-0.09%</PercentageChange>" +
                         "<AnnRange>40.12 - 50.05</AnnRange>" +
                         "<Earns>2.41</Earns>" +
                         "<P-E>19.35</P-E>" +
                         "<Name>Microsoft Corporation</Name>" +
                       "</Stock>" +
                     "</StockQuotes>" +
                    "</string>";
                XDocument doc = XDocument.Parse(input);
                var stocks = doc.Descendants("Stock").Select(x => new {
                   symbol = x.Element("Symbol").Value,
                   last = double.Parse(x.Element("Last").Value),
                   date = DateTime.Parse(x.Element("Date").Value),
                   time = DateTime.Parse(x.Element("Time").Value),
                   change = double.Parse(x.Element("Change").Value),
                   open = double.Parse(x.Element("Open").Value),
                   high = double.Parse(x.Element("High").Value),
                   low = double.Parse(x.Element("Low").Value),
                   volume = long.Parse(x.Element("Volume").Value),
                   mktcap = double.Parse(x.Element("MktCap").Value.Replace("B", "")),
                   previousClose = double.Parse(x.Element("PreviousClose").Value),
                   percentChange = double.Parse(x.Element("PercentageChange").Value.Replace("%", "")),
                   annRange = x.Element("AnnRange").Value,
                   earns = double.Parse(x.Element("Earns").Value),
                   p_e = double.Parse(x.Element("P-E").Value),
                   name = x.Element("Name").Value,
                }).ToList();
            }
        }
    }
    ​
