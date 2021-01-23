    var collection = new[]{
        new { Name = "a" },
        new { Name = "b" },
        new { Name = "c" },
        new { Name = "d" }
    };
    System.Web.Script.Serialization.JavaScriptSerializer s = new System.Web.Script.Serialization.JavaScriptSerializer();
    Console.WriteLine(s.Serialize(collection));
