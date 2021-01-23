    public class XmlDevice
    {
        // ...
        public abstract Device CreateDevice();
        // ...
    }
    public class XmlModem
    {
        // ...
        public override Device CreateDevice()
        {
            return new XmlModem(this);
        }
        // ...
    }
