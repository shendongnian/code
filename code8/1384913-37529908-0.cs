    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                var data = XDocument.Load(FILENAME); 
                Event _event = Event.FromXml(data.Descendants("event").FirstOrDefault());
            }
        }
        public class Event
        {
            public string title { get ; set; }
            public string icon  {get; set; }
            public string uri  { get; set; }
            public string mode { get;set; }
            public decimal price { get; set; }
            public string cover { get; set; }
            public DateTime enddate { get; set; }
            public DateTime startdate { get; set; }
            public string address { get; set; }
            public string location { get; set; }
            public string description { get; set; }
            public string shortdescription { get; set; }
            public string theme { get; set; }
            public uint color { get; set; }
            public static Event FromXml(XElement data)
            {
                Event _event = new Event();
                _event.title = (string)data.Attribute("title");
                _event.icon = (string)data.Attribute("icon");
                _event.uri = (string)data.Attribute("uri");
                _event.mode = (string)data.Attribute("mode");
                _event.price = (decimal)data.Attribute("price");
                _event.cover = (string)data.Attribute("cover");
                _event.enddate = (DateTime)data.Attribute("enddate");
                _event.startdate = (DateTime)data.Attribute("startdate");
                _event.address = (string)data.Attribute("address");
                _event.location = (string)data.Attribute("location");
                _event.description = (string)data.Attribute("description");
                _event.shortdescription = (string)data.Attribute("shortdescription");
                _event.theme = (string)data.Attribute("theme");
                _event.color = uint.Parse(data.Attribute("color").Value.Substring(1), System.Globalization.NumberStyles.HexNumber) ;
                return _event;
            }
        }
    }
