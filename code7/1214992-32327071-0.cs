    public class Button
    {
       IButtonServer _buttonServer;
       private bool _amIOn;
       public Button(IButtonServer buttonServer)
       {
          _buttonServer = buttonServer;
       }
       void Poll()
       {
         _amIOn = !_amIOn;
         if(_amIOn) _buttonServer.TurnOn(); else _buttonServer.TurnOff();
       }
    }
    interface ITurnOnOffableDevice
    {
       void TurnOn();
       void TurnOff();
    }
    interface IButtonServer : ITurnOnOffableDevice
    {
       void RegisterDevice(ITurnOnOffableDevice l);
    }
    
    public Lamp : ITurnOffableDevice
    {
       public Lamp(IButtonServer buttonServer)
       {
         buttonServer.RegisterDevice(this);
       }
       public void TurnOn()
       {
         Shine();
       }
       public void TurnOff()
       {
         Darken();
       } 
    }
    public MeatTriturator : ITurnOffableDevice
    {
       public MeatTriturator(IButtonServer buttonServer)
       {
         buttonServer.RegisterDevice(this);
       }
       public void TurnOn()
       {
         Triturate();
       }
       public void TurnOff()
       {
         ShutItDown();
       } 
    }
