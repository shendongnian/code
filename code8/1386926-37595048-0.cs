    public struct USB_PROTOCOLS
    {
        UInt32 protocols;
    
        public bool Usb110 { get { return (this.protocols & 0x01) == 0x01; } }
        public bool Usb200 { get { return (this.protocols & 0x02) == 0x02; } }
        public bool Usb300 { get { return (this.protocols & 0x04) == 0x04; } }
    }
