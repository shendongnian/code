        [XmlRoot(ElementName = "address_component")]
        public class Address_component
        {
            [XmlElement(ElementName = "long_name")]
            public string Long_name { get; set; }
            [XmlElement(ElementName = "short_name")]
            public string Short_name { get; set; }
            [XmlElement(ElementName = "type")]
            public List<string> Type { get; set; }
        }
        [XmlRoot(ElementName = "location")]
        public class Location
        {
            [XmlElement(ElementName = "lat")]
            public string Lat { get; set; }
            [XmlElement(ElementName = "lng")]
            public string Lng { get; set; }
        }
        [XmlRoot(ElementName = "southwest")]
        public class Southwest
        {
            [XmlElement(ElementName = "lat")]
            public string Lat { get; set; }
            [XmlElement(ElementName = "lng")]
            public string Lng { get; set; }
        }
        [XmlRoot(ElementName = "northeast")]
        public class Northeast
        {
            [XmlElement(ElementName = "lat")]
            public string Lat { get; set; }
            [XmlElement(ElementName = "lng")]
            public string Lng { get; set; }
        }
        [XmlRoot(ElementName = "viewport")]
        public class Viewport
        {
            [XmlElement(ElementName = "southwest")]
            public Southwest Southwest { get; set; }
            [XmlElement(ElementName = "northeast")]
            public Northeast Northeast { get; set; }
        }
        [XmlRoot(ElementName = "geometry")]
        public class Geometry
        {
            [XmlElement(ElementName = "location")]
            public Location Location { get; set; }
            [XmlElement(ElementName = "location_type")]
            public string Location_type { get; set; }
            [XmlElement(ElementName = "viewport")]
            public Viewport Viewport { get; set; }
            [XmlElement(ElementName = "bounds")]
            public Bounds Bounds { get; set; }
        }
        [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "type")]
            public List<string> Type { get; set; }
            [XmlElement(ElementName = "formatted_address")]
            public string Formatted_address { get; set; }
            [XmlElement(ElementName = "address_component")]
            public List<Address_component> Address_component { get; set; }
            [XmlElement(ElementName = "geometry")]
            public Geometry Geometry { get; set; }
            [XmlElement(ElementName = "place_id")]
            public string Place_id { get; set; }
        }
        [XmlRoot(ElementName = "bounds")]
        public class Bounds
        {
            [XmlElement(ElementName = "southwest")]
            public Southwest Southwest { get; set; }
            [XmlElement(ElementName = "northeast")]
            public Northeast Northeast { get; set; }
        }
        [XmlRoot(ElementName = "GeocodeResponse")]
        public class GeocodeResponse
        {
            [XmlElement(ElementName = "status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "result")]
            public List<Result> Result { get; set; }
        }
