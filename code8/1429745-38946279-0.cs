    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var ota_HotelInvCountNotifRQ = doc.Descendants().Where(x => x.Name.LocalName == "OTA_HotelInvCountNotifRQ").Select(y => new OTA_HotelInvCountNotifRQ()
                {
                    echotoken = (string)y.Attribute("echotoken"),
                    timeStampField = DateTime.Parse((string)y.Attribute("timestamp")),
                    versionField = (decimal)y.Attribute("version"),
                    sequencenmbr = (int)y.Attribute("sequencenmbr"),
                    hotelCode = (string)y.Descendants().Where(z => z.Name.LocalName == "Inventories").FirstOrDefault().Attribute("HotelCode"),
                    hotelName = (string)y.Descendants().Where(z => z.Name.LocalName == "Inventories").FirstOrDefault().Attribute("HotelName"),
                    start = (DateTime)y.Descendants().Where(z => z.Name.LocalName == "StatusApplicationControl").FirstOrDefault().Attribute("Start"),
                    end = (DateTime)y.Descendants().Where(z => z.Name.LocalName == "StatusApplicationControl").FirstOrDefault().Attribute("End"),
                    invTypeCode = (string)y.Descendants().Where(z => z.Name.LocalName == "StatusApplicationControl").FirstOrDefault().Attribute("InvTypeCode"),
                    _override = (Boolean)y.Descendants().Where(z => z.Name.LocalName == "StatusApplicationControl").FirstOrDefault().Attribute("Override"),
                    countType = (int)y.Descendants().Where(z => z.Name.LocalName == "InvCount").FirstOrDefault().Attribute("CountType"),
                    count = (int)y.Descendants().Where(z => z.Name.LocalName == "InvCount").FirstOrDefault().Attribute("Count"),
                }).FirstOrDefault();
            }
        }
        public class OTA_HotelInvCountNotifRQ
        {
            public string echotoken { get; set; }
            public DateTime timeStampField { get; set; }
            public decimal versionField { get; set; }
            public int sequencenmbr { get; set; }
            public string hotelCode { get; set; }
            public string hotelName { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public string invTypeCode { get; set; }
            public Boolean _override { get; set; }
            public int count { get; set; }
            public int countType { get; set; }
        }
    }
