    // column aspect names are the names of these properties
    public class AspectBindable
    {
      public string ObjectName { get; set; }
      public string ObjectType { get; set; }
    }
    // level 2 info
    public class Sistem : AspectBindable { public IList <Device> Devices { get; set; } }
    //level 1
    public class Location : AspectBindable { public IList<Sistem> Systems { get; set; } }
    //level 3 
    public class Device : AspectBindable { }
