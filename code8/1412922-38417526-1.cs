      internal class Program
      {
        private static void Main(string[] args)
        {
          //var r = readFromWeb("http://www.808.dk/?code-csharp-httpwebrequest");
          var r = readFromWeb("http://services.groupkt.com/country/get/all");
          Trace.Write(r);
        }
    
        private static MyJson readFromWeb(string url)
        {
          var request = WebRequest.Create(url) as HttpWebRequest;
          request.ContentType = "application/json";
          request.Method = "GET";
          var response = request.GetResponse() as HttpWebResponse;
          var webStream = response.GetResponseStream();
          var json = new DataContractJsonSerializer(typeof (MyJson));
          var resttresponse = (MyJson) json.ReadObject(webStream);
          return resttresponse;
        }
      }
    
      [DataContract]
      public class MyJson
      {
        [DataMember(Name = "RestResponse")]
        public RestResponse RestResponse { get; set; }
      }
    
      [DataContract]
      public class RestResponse
      {
        [DataMember(Name = "messages")]
        public string[] messages { get; set; }
    
        [DataMember(Name = "result")]
        public City[] result { get; set; }
      }
    
      [DataContract]
      public class City
      {
        [DataMember(Name = "name")]
        public string name { get; set; }
    
        [DataMember(Name = "alpha2_code")]
        public string alpha2_code { get; set; }
    
        [DataMember(Name = "alpha3_code")]
        public string alpha3_code { get; set; }
      }
