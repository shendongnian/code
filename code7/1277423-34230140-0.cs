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
                List<XElement> userBooks = doc.Descendants("userBooks").ToList();
                foreach(XElement userBook in userBooks)
                {
                    userBook.ReplaceWith(userBook.Element("genre"));
                }
            }
        }
    }
    ​
