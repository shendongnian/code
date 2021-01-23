    using System;
    using System.Xml.Serialization;
    
    namespace Sandbox2
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                var now = DateTime.Now;
                var m = new Moment () { Timestamp = now };
                var xs = new XmlSerializer (typeof(Moment));
                xs.Serialize (Console.Out, m);
            }
        }
    
        public class Moment
        {
            [XmlElement("Timestamp")]
            public string BackingTimestamp;
    
            [XmlIgnore]
            public DateTime Timestamp
            {
                get
                {
                    return DateTime.Parse (BackingTimestamp);
                }
                set
                {
                    BackingTimestamp = value.ToString ("yyyy-MM-ddTHH:mm:ssK");
                }
            }
        }
    }
