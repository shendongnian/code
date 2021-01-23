    [XmlRoot("tms_msg")]
        public class TmsMessage
        {
            [XmlElement("transaction")]
            public Transaction Transaction;
        }
    
        public class Transaction
        {
            [XmlElement("message_string", typeof(ComplexType))]
            public ComplexType[] ComplexObjects { get; set; }
        }
    
        public class ComplexType
        {
            [XmlElement("latitue")]
            public string Latitude { get; set; }
    
            [XmlElement("longitude")]
            public string Longitude { get; set; }
    
            [XmlText]
            public String Text { get; set; }
    
            //in other part of source code of this class, check the object type.
            //if it's type1 then property Text gets null; if it's type 2, property 
            //Latitude and Longitude get null.
        }
