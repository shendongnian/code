    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication96
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<root><tag1>text1</tag1><tag2>text2></tag2></root>";
                XElement root = XElement.Parse(xml);
                Dictionary<string, string> dict1 = new Dictionary<string, string>();
                //if each tag is unique
                dict1 = root.Elements().GroupBy(x => x.Name.LocalName, y => y).ToDictionary(x => x.Key, y => y.FirstOrDefault().Value);
                //if tag names are duplicated then use this
                Dictionary<string, List<string>> dict2 = new Dictionary<string, List<string>>();
                dict2 = root.Elements().GroupBy(x => x.Name.LocalName, y => y).ToDictionary(x => x.Key, y => y.Select(z => z.Value).ToList());
             }
        }
    }
