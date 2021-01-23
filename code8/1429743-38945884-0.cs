    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                try
                {
                    OTA_HotelInvCountNotifRQ ota_HotelInvCountNotifRQ = new OTA_HotelInvCountNotifRQ();
                    string envelope = File.ReadAllText(FILENAME);
                    OTA_HotelInvCountNotifRQ  serializedData =  ota_HotelInvCountNotifRQ.DeserializeResXMl(envelope);
                }
                catch (Exception e)
                {
                    string message = e.Message;
                    string stacktrace = e.StackTrace;
                }
            }
        } 
        [XmlRoot( ElementName = "envelope")]
        public class Envelope
        {
            [XmlElement(ElementName = "body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body body { get; set; }
        }
        [XmlRoot(ElementName = "body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "OTA_HotelInvCountNotifRQ", Namespace = "http://www.example.com/OTA/2003/05")]
            public OTA_HotelInvCountNotifRQ ota_HotelInvCountNotifRQ { get; set; }
        }
     
        [XmlRoot(ElementName = "OTA_HotelInvCountNotifRQ", Namespace = "http://www.example.com/OTA/2003/05")]
        public partial class OTA_HotelInvCountNotifRQ
        {
            private InvCountType inventoriesField;
            private string echoTokenField;
            private System.DateTime timeStampField;
            private OTA_HotelInvCountNotifRQTarget targetField;
            private decimal versionField;
            public OTA_HotelInvCountNotifRQ()
            {
                this.targetField = OTA_HotelInvCountNotifRQTarget.Production;
            }
            /// <remarks/>
            public InvCountType Inventories
            {
                get
                {
                    return this.inventoriesField;
                }
                set
                {
                    this.inventoriesField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string EchoToken
            {
                get
                {
                    return this.echoTokenField;
                }
                set
                {
                    this.echoTokenField = value;
                }
            }
            public OTA_HotelInvCountNotifRQ DeserializeResXMl(string envelopeStr)
            {
                OTA_HotelInvCountNotifRQ ret = null;
                if (envelopeStr != null && envelopeStr != string.Empty)
                {
                    try
                    {
                        long TimeStart = DateTime.Now.Ticks;
                        XmlSerializer serializer;
                        //serializer = new XmlSerializer(typeof(OTA_HotelInvCountNotifRQ));
                        serializer = new XmlSerializer(typeof(Envelope));
                        Envelope  envelope =  (Envelope)serializer.Deserialize(new StringReader(envelopeStr));
                        ret = envelope.body.ota_HotelInvCountNotifRQ;
                    }
                    catch (Exception e)
                    {
                        ret = null;
                    }
                }
                return ret;
            }
        }
        public class InvCountType
        {
        }
        public class OTA_HotelInvCountNotifRQTarget
        {
            public static OTA_HotelInvCountNotifRQTarget Production { get; set; }
        }
    }
