    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HtmlAgilityPack;
    
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var html = new HtmlDocument();
                html.Load("C:\\test\\test.html");
                html.OptionOutputAsXml = true;
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Xml.XmlTextWriter xw = new System.Xml.XmlTextWriter(sw);
                html.Save("C:\\test\\test.xml");
            }
        }
    }
