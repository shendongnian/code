    static void Main(string[] args)
        {
            var client = new RestClient("http://192.168.0.3:1337/auto/api/v1.0/");
            var request = new RestRequest("relays", Method.GET);  
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
    
            var response = client.Execute<Relay>(request);
            JavaScriptSerializer ser = new JavaScriptSerializer();
              var relayList = ser.Deserialize<List<Relay>>(response.Content);
             foreach(Relay relay in relayList) 
            Console.WriteLine(relay.ID);
            Console.ReadLine();
        }
