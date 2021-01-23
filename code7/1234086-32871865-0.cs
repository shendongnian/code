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
                    "<Profiles>" +
                        "<ProfileInfo>" +
                        "<Profile>" +
                        "<name>test1</name>" +
                        "<age>2</age>" +
                        "</Profile>" +
                        "<Profile>" +
                        "<name>test2</name>" +
                        "<age>2</age>" +
                        "</Profile>" +
                        "<Profile>" +
                        "<name>test3</name>" +
                        "<age>2</age>" +
                        "</Profile>" +
                        "</ProfileInfo>" +
                        "</Profiles>";
                XElement element = XElement.Parse(input);
                XElement newElement = null;
                foreach (XElement profile in element.Descendants("Profile"))
                {
                    if (newElement == null)
                    {
                        newElement = profile;
                    }
                    else
                    {
                        newElement.Add(profile);
                    }
                }
            }
        }
    }
    ​
