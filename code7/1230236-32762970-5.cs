    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Xml;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        public class AgentBookingStatusResponse
        {
            public DateTime Eta { get; set; }
        }
    
        public class RootData
        {
            public AgentBookingStatusResponse AgentBookingStatusResponse { get; set; }
        }
    
        public class Program
        {
    
            static void Main(string[] args)
            {
              string testXMLData = @"<AgentBookingStatusResponse><Eta>2012-11-19T15:40:15.0819269+00:00</Eta></AgentBookingStatusResponse>";  
              
              XmlDocument doc = new XmlDocument();
              doc.LoadXml(testXMLData);
              string jsonText = JsonConvert.SerializeXmlNode(doc);
    
              //Deserialize to RootData Object
              var dataObj = JsonConvert.DeserializeObject<RootData>(jsonText);
    
              var datetime = new DateTime();
              datetime = Convert.ToDateTime(dataObj.AgentBookingStatusResponse.Eta);
              CultureInfo uk = CultureInfo.GetCultureInfo("en-GB");
              string ukDate = datetime.ToString("O", uk);
    
              Console.WriteLine(ukDate);
              Console.ReadKey();
            }
        }
    }
