    using System.Collections.Generic;
    using JsSerializer = System.Web.Script.Serialization.JavaScriptSerializer;
    using System.Net;
    //
    // http://cricapi.com/api/cricket/
    //
    namespace CricApi.Cricket
    {
       public class Provider
        {
            public string url { get; set; }
            public string source { get; set; }
            public string pubDate { get; set; }
        }
        
        public class Datum
        {
            public string title { get; set; }
            public string description { get; set; }
            public string unique_id { get; set; }
        }
        
        public class RootObject
        {
            public Provider provider { get; set; }
            public List<Datum> data { get; set; }
            public bool cache { get; set; }
        }
    }
    //
    //http://cricapi.com/api/cricketScore?unique_id=946981
    //http://cricapi.com/api/cricketScore?unique_id=946765
    //
    namespace CricApi.CricketScore
    {
      public class Provider
      {
        public string pubDate { get; set; }
        public string source { get; set; }
        public string url { get; set; }
      }
    
      public class RootObject
      {
        public bool cache { get; set; }
        public string inningsRequirement { get; set; }
        public string team2 { get; set; }
        public string team1 { get; set; }
        public string score { get; set; }
        public Provider provider { get; set; }
      }
    }
    // 
    // how to use this
    //
    namespace CricApi
    {
      class Program
      {
        static void Main (string[] args)
        {
        
          WebClient client = new WebClient();
          
          // Download cricket info
          //  dynamic dyn = JsonConvert.DeserializeObject(res);
          string cricketJson = client.DownloadString("http://cricapi.com/api/cricket/");
          Cricket.RootObject cro = new JsSerializer().Deserialize<Cricket.RootObject>(cricketJson);
    
          // Download cricket score info
          foreach (var datum in cro.data)
          {
            string uri = "http://cricapi.com/api/cricketScore?unique_id=" + datum.unique_id;
            string cricketScoreJson = client.DownloadString(uri);
            CricketScore.RootObject csro = new JsSerializer().Deserialize<CricketScore.RootObject>(cricketScoreJson);
          }
    
        }
      }
    }
