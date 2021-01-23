        public void ShowAlert(String Message, String ConnectionId)
        {
            RestClient Client = new RestClient("http://localhost:8888");
            RestRequest Request = new RestRequest("/Listener/SignalR", Method.POST);
            Request.Parameters.Add(new Parameter() { Name = "Message", Type = ParameterType.QueryString, Value = Message });
            Request.Parameters.Add(new Parameter() { Name = "Type", Type = ParameterType.QueryString, Value = "ShowAlert" });
            Request.Parameters.Add(new Parameter() { Name = "ConnectionId", Type = ParameterType.QueryString, Value = ConnectionId });
            IRestResponse Response = Client.Execute(Request);
        } // end Show Alert
