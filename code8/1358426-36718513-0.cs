    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication85
    {
        class Program
        {
            static void Main(string[] args)
            {
                //<custom>
                //    <text1>
                //    <value name="sample1">hello</value>
                //    </text1>
                //    <text1><value name="sample2">world</value> 
                //    </text1>  
                //    </custom>
                XElement custom = new XElement("custom", new object[] {
                    new XElement("Text1", new object[] {
                       new XElement("value", new object[] {
                          new XAttribute("name", "sample1"),
                          "hello"
                       })
                    }),
                    new XElement("Text1", new object[] {
                       new XElement("value", new object[] {
                          new XAttribute("name", "sample2"),
                          "world"
                       })
                    })
                });
            }
        }
    }
