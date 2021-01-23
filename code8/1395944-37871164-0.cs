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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Package> packages = doc.Descendants("Package").Select(x => new Package() {
                    Shiptracknum = (ulong)x.Element("TrackNumber"),
                    PackageWeight = (string)x.Element("PackageWeight"),
                    items = x.Elements("Items").Select(y => new Item() {
                        ShipDescription = (string)y.Element("Description"),
                        EndUserPOnumber = (string)y.Element("EndUserPOLineNo")
                    }).ToList()
                }).ToList();
            }
        }
        public class Package
        {        
            public ulong Shiptracknum { get; set; }
            public string PackageWeight { get; set; }
            public List<Item> items { get; set; }
        }
        public class Item
        {
           public string ShipDescription { get; set; }
           public string EndUserPOnumber { get; set; }
        }
    }
