    public void GetBeer(string beer)
    {
        //initialize beer list
        AdjunctsReply reply;
        //build connection with query and return string
        //***static class Connect uses System.net to create web request and web response objects***
        string result = Connect.GetConnection(address);
        //get list of Adjunct objects
        reply = JsonConvert.DeserializeObject<AdjunctsReply>(result);
        foreach(var adjunct in reply.adjuncts) 
        {
            Console.WriteLine(adjunct.name);
        }
    }
