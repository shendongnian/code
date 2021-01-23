    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication53
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                  "<Root>" +
                      "<ss type=\"tongueout\">:p</ss><ss type=\"laugh\">:D</ss>" +
                  "</Root>";
                XElement root = XElement.Parse(xml);
                XElement[]  img = new XElement[] {
                       new XElement("img", new XAttribute("src","./Emoticons/toungeout.png")), 
                       new XElement("img", new XAttribute("src", "./Emoticons/laugh.png")) 
                };
                XElement ss = root.Element("ss");
                ss.ReplaceWith(img);
            }
        }
    }
