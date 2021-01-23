    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication3
    {
        [Serializable]
        public class Pallet
        {
            public class Box
            {
                public string Name { get; set; }
                public int Size { get; set; }
            }
    
            public Box b1 = new Box();
            public Box b2 = new Box();
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                //create your object and populate it
                Pallet p = new Pallet();
                p.b1.Name = "Fred";
                p.b1.Size = 5;
                p.b2.Name = "Bob";
                p.b2.Size = 10;
    
    
                //#### wrap up the object into XML string ####
    
                XmlSerializer xs = new XmlSerializer(typeof(Pallet), "PalletNS");
                StringBuilder sb = new StringBuilder();
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Encoding = Encoding.UTF8;
                XmlWriter xw = XmlWriter.Create(sb, xws);
    
                xs.Serialize(xw, p); //generate the XML string
                
                //#### pallet is now stored in XML string inside sb
                Console.WriteLine(sb.ToString());
    
                //#### unwrap the pallet into an Xml structure that you can query easily with strings
    
                XmlDocument xdoc = new XmlDocument();
                xdoc.PreserveWhitespace = true;
                xdoc.LoadXml(sb.ToString());
    
                /* The XML serialized class looks like this...
                 
                <?xml version="1.0" encoding="utf-16"?>
                    <Pallet xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                            xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                            xmlns="PalletNS">
                        <b1>
                            <Name>Fred</Name>
                            <Size>5</Size>
                        </b1>
                        <b2>
                            <Name>Bob</Name>
                            <Size>10</Size>
                        </b2>
                    </Pallet>
                */
    
    
    
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
                nsmgr.AddNamespace("x", "PalletNS");
                //get a reference to the top of the XML tree
                XmlElement root = xdoc.DocumentElement;
    
                //run an XPathQuery to pull a node that we're interested...
                //in english: "Grab the Name of the first b2 item"
                XmlNode xn = root.SelectSingleNode("./x:b2/x:Name", nsmgr);
    
                //and print it's name to the console...
                Console.WriteLine("\n\n" + xn.InnerText);
                
                Console.WriteLine("\n\nPress enter to quit.");
                Console.ReadLine();
            }
        }
    }
