    class XmlDevice
    {
        // ...
        public abstract Device CreateDevice();
        // ...
    }
    class XmlModem
    {
        // ...
        public override Device CreateDevice()
        {
            return new Modem(this);
        }
        // ...
    }
