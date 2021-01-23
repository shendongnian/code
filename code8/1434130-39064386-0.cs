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
                string input = "<meta name=\"pubdate\" content=\"2012-08-30\" />";
                XElement meta = XElement.Parse(input);
                DateTime output = (DateTime)meta.Attribute("content");
            }
        }
    }
