    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        [XmlRoot("Something")]
        public class Something
        {
            [XmlElement("Creature")]
            List<string> creature { get; set; }
        }
    }​
