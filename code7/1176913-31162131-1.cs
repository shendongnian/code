    var outputJson = new OutputJson{
        Android = new List<Entity> 
        {
            new Entity { Name = "aaa", Version = "123"},
            new Entity { Name = "bb", Version = "34"},
            new Entity { Name = "cc", Version = "56"},
        }   
    var output = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(outputJson); 
