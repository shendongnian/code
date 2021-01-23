    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<ns1:foo xmlns:ns1=\"http://some.name/space\">" +
                      "<ns1:bar>" +
                        "<ns1:payload interesting=\"true\">" +
                          "<ns1:stuff type=\"interesting\"/>" +
                        "</ns1:payload>" +
                      "</ns1:bar>" +
                    "</ns1:foo>";
                //remove prefix
                string pattern = "(</?)([^:]*:)";
                Regex expr = new Regex(pattern);
                input = expr.Replace(input, "$1");
                XmlSerializer xs = new XmlSerializer(typeof(Foo));
                StringReader s_reader = new StringReader(input);
                XmlTextReader reader = new XmlTextReader(s_reader);
                Foo  foo = (Foo)xs.Deserialize(reader);
                foo.GetStuff();
            }
        }
        [XmlRoot(ElementName = "foo")]
        public class Foo
        {
            [XmlElement("bar")]
            public Bar bar { get; set; }
            private Boolean interesting;
            private string type;
            public void GetStuff()
            {
                interesting = bar.payload.interesting;
                type = bar.payload.stuff.type;
            }
        }
        [XmlRoot("bar")]
        public class Bar
        {
            [XmlElement("payload")]
            public Payload payload { get; set; }
        }
        [XmlRoot("payload")]
        public class Payload
        {
            [XmlAttribute("interesting")]
            public Boolean interesting { get; set; }
            [XmlElement("stuff")]
            public Stuff stuff { get; set; }
        }
        [XmlRoot("stuff")]
        public class Stuff
        {
            [XmlAttribute("type")]
            public string type { get; set; }
        }
    }
    ​
