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
        [XmlRoot("MailItem")]
        public class MailItem
        {
            [XmlElement("UniqueEmailId")]
            public string UniqueEmailId { get; set; }
            [XmlElement("SenderEmailId")]
            public string SenderEmailId { get; set; }
            [XmlElement("ToRecipientEmailId")]
            public string[] ToRecipientEmailId { get; set; }
        }
    }
    ​
