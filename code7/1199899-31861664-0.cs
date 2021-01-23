    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Stream stream = File.Open(FILENAME, FileMode.Open);
                AvailabilityResponse availabilityResponse = DeserializeAvailabilityResponse(stream);
            }
            public static AvailabilityResponse DeserializeAvailabilityResponse(Stream replyStream)
            {
                AvailabilityResponse availabilityResponse = null;
                XmlReader inreader = null;
                if (replyStream != null)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(AvailabilityResponse));
                    inreader = new XmlTextReader(replyStream);
                    availabilityResponse = (AvailabilityResponse)xs.Deserialize(inreader);
                    return availabilityResponse;
                }
                else
                {
                    return null;
                }
            }
     
        }
        [XmlRoot("AvailabilityResponse")]
        public class AvailabilityResponse
        {
            [XmlElement("ApiKey")]
            public string ApiKey { get; set; }
            [XmlElement("ResellerId")]
            public int ResellerId { get; set; }
            [XmlElement("SupplierId")]
            public int SupplierId { get; set; }
            [XmlElement("ForeignReference")]
            public string ForeignReference { get; set; }
            [XmlElement("Timestamp")]
            public DateTime Timestamp { get; set; }
            [XmlElement("RequestStatus")]
            public RequestStatus RequestStatus { get; set; }
            [XmlElement("TTAsku")]
            public string TTAsku { get; set; }
            [XmlElement("TourAvailability")]
            public List<TourAvailability> TourAvailability { get; set; }
        }
        [XmlRoot("RequestStatus")]
        public class RequestStatus
        {
            [XmlElement("Status")]
            public string Status { get; set; }
        }
        [XmlRoot("TourAvailability")]
        public class TourAvailability
        {
            [XmlElement("TourDate")]
            public DateTime TourDate { get; set; }
            [XmlElement("TourOptions")]
            public TourOptions TourOptions { get; set; }
            [XmlElement("AvailabilityStatus")]
            public AvailabilityStatus AvailabilityStatus { get; set; }
        }
        [XmlRoot("TourOptions")]
        public class TourOptions
        {
            public DateTime dTime { get; set; }
            [XmlElement("DepartureTime")]
            public string DepartureTime
            {
                get
                {
                    return this.dTime.ToString("hh:mm tt");
                }
                set
                {
                    this.dTime = DateTime.ParseExact(value, "hh:mm tt", CultureInfo.InvariantCulture);
                }
            }
               
        }
     
        [XmlRoot("AvailabilityStatus")]
        public class AvailabilityStatus
        {
            [XmlElement("Status")]
            public string Status { get; set; }
            [XmlElement("UnavailabilityReason")]
            public string UnavailabilityReason { get; set; }
        }
    }
    ​
