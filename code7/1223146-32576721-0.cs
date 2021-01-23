    public class Behaviours:Dictionary<Device, Response>
    {
       public void Add(Device d)
       {
           var r= new response(d);
           Add(d, r);
       }
    }
    
    ...
    
    private Behaviours _behaviours = new Behaviours{
      {new Device()},
      {new Device()},
      {new Device()},
    }
