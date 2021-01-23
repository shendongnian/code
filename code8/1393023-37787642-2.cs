    public abstract class XmlDevice
    {
        // ...
        public abstract Device CreateDevice();
        // ...
    }
    public class XmlModem : XmlDevice
    {
        // ...
        public override Device CreateDevice()
        {
            return new Modem(this);
        }
        // ...
    }
