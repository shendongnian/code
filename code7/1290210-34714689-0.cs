    string url = "http://localhost:4444/grid/api/testsession?session=" + this.SessionId;
    WebClient client = new WebClient();
    Stream stream = client.OpenRead(url);
    StreamReader reader = new StreamReader(stream);
    Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
    string host = new Uri(jObject.GetValue("proxyId").ToString()).Host;
    stream.Close();
    
    Console.WriteLine(host);
