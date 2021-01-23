    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Xml.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject2
    {
        [TestClass]
        public class Class7
        {
            [TestMethod]
            public void xmltest()
            { 
                string xml = @"<body><postapplication_v6response><postapplication_v6result>&lt;xxxService&gt;
    &lt;Application&gt;
    &lt;Status&gt;PURCHASED&lt;/Status&gt;
    &lt;RedirectURL&gt;http://www.google.com?test=abc&amp;xyz=123&lt;/RedirectURL&gt;
    &lt;/Application&gt;
    &lt;/xxxService&gt;
    </postapplication_v6result></postapplication_v6response></body>";
    
                XDocument doc = XDocument.Parse(xml);
                string encodedhtml = doc.Descendants("postapplication_v6result")
                        .First().Value;
    
                string decodedhtml = HttpUtility.HtmlDecode(encodedhtml);
    
                Console.WriteLine(decodedhtml);
            }
        }
    }
