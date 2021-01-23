    public ButtonServer : IButtonServer
    {
       private List<ITurnOnOffableDevice> _devices = new List<ITurnOnOffAbleDevice>();
       public void RegisterDevice(ITurnOnOffAbleDevice l)
       {
         _devices.Add(l);
       }
       public void TurnOn()
       {
         foreach(var l in _devices) { l.TurnOn(); }
       }
       public void TurnOff()
       {
         foreach(var l in _devices) { l.TurnOff(); }
       }
    }
   
