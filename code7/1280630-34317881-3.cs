    static void Main(string[] args)
        {
            // this is my Web API Endpoint
            var req = (HttpWebRequest)WebRequest.Create("http://localhost:17512/api/MyClass");
            // default is JSON, but you can request XML
            req.Accept = "application/xml";
            req.ContentType = "application/xml";
            var resp = req.GetResponse();
            var sr = new StreamReader(resp.GetResponseStream());
            // read the response stream as Text.
            var xml = sr.ReadToEnd();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            // Deserialize
            var ser = new XmlSerializer(typeof(MyClass));
            var instance = (MyClass)ser.Deserialize(ms);
            Console.WriteLine(instance.A);
            Console.WriteLine(instance.b);
            var final = Console.ReadLine();
        }
