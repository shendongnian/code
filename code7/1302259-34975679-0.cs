    using System.IO;
    using System.Net;
    using Newtonsoft.Json.Linq;
    ...
    WebClient client = new WebClient();
    Stream stream = client.OpenRead("http://site.web/api/public/user?name=Usename");
    StreamReader reader = new StreamReader(stream);
    string userJson = reader.ReadLine();
    reader.Close();
    
    JObject jObject = JObject.Parse(userJson);
    string uniqueId = (string)jObject["uniqueId"];
