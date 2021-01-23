    string jsonInput = "{\"json\":\"testvalue\"}";
    using (var client = new WebClient())
    {
         client.Headers["Content-type"] = "application/json";
         client.Encoding = System.Text.Encoding.UTF8;
         client.UploadString("http://localhost:51175/Service1.svc/PostBack", "POST", jsonInput); 
    }
