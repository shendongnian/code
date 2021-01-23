    public class Behaviours:Dictionary<Device, Response>
    {
       new public void Add(Device d)
       {
           var r= new response(d);
           (this as Dictionary<Device, Response>).Add(d, r);
       }
    }
    
    ...
    
    private Behaviours _behaviours = new Behaviours{
      {new Device()},
      {new Device()},
      {new Device()},
    }
