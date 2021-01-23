    public class MyObject
    {
      public string caption {get;set;}
      public string link {get;set;}
      public bool newWindow {get;set;}
      public bool edit {get;set;}
      public bool isInternal {get;set;}
      public string type{get;set;}
      public string title{get;set;}
    }
    List<MyObject> obj = JsonConvert.DeserializeObject<List<MyObject>>(json); // json is a string
    if(obj.Count > 0)
    {
       string link = obj[0].link;
    }
