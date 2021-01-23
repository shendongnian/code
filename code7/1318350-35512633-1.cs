    using Newtonsoft.Json;
    ...
    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public Message GetDict()
    {
    	Dictionary<string, CompositeType> dict = new Dictionary<string, CompositeType>();
    	dict.Add("fred", new CompositeType { HasPaid = false, Owner = "Fred Millhouse" });
    	dict.Add("joe", new CompositeType { HasPaid = false, Owner = "Joe McWirter" });
    	dict.Add("bob", new CompositeType { HasPaid = true, Owner = "Bob Smith" });
    
    	string json = JsonConvert.SerializeObject(dict);
    	return WebOperationContext.Current.CreateTextResponse(json, "application/json; charset=utf-8", Encoding.UTF8);
    }
