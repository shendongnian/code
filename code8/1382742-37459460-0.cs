    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<SET_RULES>" +
                        "<DOMAIN_RULES>" +
                        "<RULE1>user1,user2,user3,user4</RULE1>" +
                        "<RULE2>test2</RULE2>" +
                        "<RULE3>test3</RULE3>" +
                        "<RULE4>test4</RULE4>" +
                        "</DOMAIN_RULES>" +
                    "</SET_RULES>";
                XElement rules = XElement.Parse(xml);
                string output = string.Join(",",
                    rules.Descendants("DOMAIN_RULES").Elements().Select(x => (string)x).ToArray());
                string[] outputArray = output.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
