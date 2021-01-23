    var RegisteredUsers = new List<Rootobject>();
    RegisteredUsers.Add(new Rootobject() { children = { }, data = { }, 
                                       id = "102", name = "zaki" });
			RegisteredUsers.Dump();						   
									   
									   
									   
									   }
    public class Rootobject{
    public Child[] children { get; set; }
    public Data data { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    }
    public class Data{
       //  public string name { get; set; }
     }
    public class Child{
      public Child1[] children { get; set; }
       public Data1 data { get; set; }
       public string id { get; set; }
       public string name { get; set; }
    }
    public class Data1{
    public int playcount { get; set; }
    public int area { get; set; }
    }
    public class Child1{
      public object[] children { get; set; }
      public Data2 data { get; set; }
      public string id { get; set; }
      public string name { get; set; }
    }
