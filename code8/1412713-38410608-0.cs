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
                Test test = new Test();
                int results = test.GetDefaultValue("A", "One");
            }
        }
        public class Test
        {
            const string FILENAME = @"c:\temp\test.xml";
            XDocument xml = null;
            public Test()
            {
                xml = XDocument.Load(FILENAME);
            }
            public int GetDefaultValue(string dataBlock, string propName)
            {
                return xml.Descendants("data")
                    .Where(x => (string)x.Element("dataname") == dataBlock)
                    .Descendants("property")
                    .Where(y => (string)y.Element("name") == propName)
                    .Select(z => (int)z.Element("value")).FirstOrDefault();
            }
        }
    }
