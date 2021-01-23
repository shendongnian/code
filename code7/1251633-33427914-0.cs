        [Serializable]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public class tms_msg
        {
            [System.Xml.Serialization.XmlElementAttribute("transaction")]
            public tms_msgTransaction[] transaction { get; set; }
        }
        [Serializable]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class tms_msgTransaction
        {
            public tms_msgTransactionMessage_string message_string { get; set; }
        }
        [Serializable]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public class tms_msgTransactionMessage_string
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text { get; set; }
        }
