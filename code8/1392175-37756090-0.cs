    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                "H1|57535                 |65644474|       243.34\n" +
                "D1|671690160540      |FedEx Gnd   |Ground          |Parcel |06082016\n" +
                "D2|FCREADHCU3     |    10|     23.01\n" +
                "H1|57521                 |65642336|       923.31\n" +
                "D1|671690161010      |FedEx Gnd   |Ground          |Parcel |06082016\n" +
                "D2|PS121B         |     1|      0.00\n" +
                "H1|57521                 |65642336|       923.31\n" +
                "D1|671690161031      |FedEx Gnd   |Ground          |Parcel |06082016\n" +
                "D2|PS121B         |     1|      0.00\n" +
                "H1|57521                 |65642336|       923.31\n" +
                "D1|671690161020      |FedEx Gnd   |Ground          |Parcel |06082016\n" +
                "D2|PS121B         |     1|      0.00\n";
                StringReader reader = new StringReader(input);
                string inputLine = "";
                Package package = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if(input.Length > 0)
                    {
                        string[] splitRow = inputLine.Split(new char[] {'|'}).Select(x => x.Trim()).ToArray();
                        switch(splitRow[0])
                        {
                            case "H1" :
                                package = new Package();
                                package.id1 = splitRow[1];
                                package.id2 = splitRow[2];
                                package.weight = Decimal.Parse(splitRow[3]);
                                break;
                            case "D1" :
                                package.id3 = splitRow[1];
                                package.type1 = splitRow[2];
                                package.type2 = splitRow[3];
                                package.type3 = splitRow[4];
                                package.id4 = splitRow[5];
                                break;
                            case "D2" :
                                package.id5 = splitRow[1];
                                package.quantity = int.Parse(splitRow[2]);
                                package.cost = decimal.Parse(splitRow[3]);
                                StorePackage(package);
                                package = null;
                                break;
                        }
                    }
                }
            }
            static void StorePackage(Package package)
            {
            }
        }
        public class Package
        {
            public int quantity { get; set; }
            public string id1 { get; set; }
            public string id2 { get; set; }
            public string id3 { get; set; }
            public string id4 { get; set; }
            public string id5 { get; set; }
            public string type1 { get; set; }
            public string type2 { get; set; }
            public string type3 { get; set; }
            public decimal weight { get; set; }
            public decimal cost { get; set; }
     
        }
    }
