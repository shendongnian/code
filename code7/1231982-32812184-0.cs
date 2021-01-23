    public static class PlacesHelper
    {
        private const string EndpointUrl = "http://www.smartpost.ee/places.xml";
        /// <summary> Load array of places </summary>
        public static async Task<Places> LoadPlacesAsync()
        {
            var xmlString = await HttpRequestHelper.DownloadStringAsync(EndpointUrl);
            return SerializationHelper.DeserializeXmlString<Places>(xmlString);
        }
    }
    public static class SerializationHelper
    {
        /// <summary> Deserializes Xml string of type T. </summary>
        public static T DeserializeXmlString<T>(string xmlString)
        {
            T tempObject = default(T);
            using (var memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
            {
                var xs = new XmlSerializer(typeof (T));
                var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                tempObject = (T) xs.Deserialize(memoryStream);
            }
            return tempObject;
        }
        /// <summary> Convert String to Array </summary>
        private static Byte[] StringToUTF8ByteArray(String xmlString)
        {
            return new UTF8Encoding().GetBytes(xmlString);
        }
    }
    public static class HttpRequestHelper
    {
        /// <summary> Download String Async </summary>
        public static async Task<string> DownloadStringAsync(string uri)
        {
            var client = new WebClient();
            return await client.DownloadStringTaskAsync(uri);
        }
    }
    [Serializable]
    [XmlRoot("places_info", Namespace = "")]
    public class Places
    {
        [XmlElement("place", typeof(Place), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public Place[] Place { get; set; }
    }
    [Serializable]
    public class Place
    {
        [XmlElement("place_id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("address")]
        public string Address { get; set; }
    }
