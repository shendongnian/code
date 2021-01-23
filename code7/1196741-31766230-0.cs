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
                //<FileContents>
                //<FileContent>
                //<Metadata>
                //<Country>UK</Country>
                //<CounterPartyType>Legal</CounterPartyType>
                //</Metadata>
                //</FileContent>
                //<FileContent>
                //<Metadata>
                //<Country>USA</Country>
                //<CounterPartyType>Legal</CounterPartyType>
                //</Metadata>
                //</FileContent
                XElement filecontents = new XElement("FileContents");
                XElement filecontent = null;
                XElement metadata = null;
                
                filecontent = new XElement("FileContent");
                filecontents.Add(filecontent);
                metadata = new XElement("Metadata");
                filecontent.Add(metadata);
                metadata.Add(new XElement("Country","UK"));
                metadata.Add(new XElement("CounterPartyType","Legal"));
                filecontent = new XElement("FileContent");
                filecontents.Add(filecontent);
                metadata = new XElement("Metadata");
                filecontent.Add(metadata);
                metadata.Add(new XElement("Country", "USA"));
                metadata.Add(new XElement("CounterPartyType", "Legal"));
            }
        }
    }
    ​
