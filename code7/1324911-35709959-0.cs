    using Newtonsoft.Json;
    using System;
    class Program
    {
      class Wrapper
      {
        public string Url { get; set; }
      }
            
      static void Main(string[] args)
      {
      	Wrapper data = JsonConvert.DeserializeObject<Wrapper>("{\"Url\":\"http://repreeapi.cloudapp.net/PublicApi/{ActionName}/f23284d5-90a7-4c41-9bd4-8a47e64b4a75\"}");
      	string url = data.Url.Replace("{ActionName}", "launch");
      	Console.WriteLine(url);
      }
    }
