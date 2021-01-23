    public struct USB_NODE_CONNECTION_INFORMATION_EX_V2_FLAGS
    {
        UInt32 flags;
    
        public bool DeviceIsOperatingAtSuperSpeedOrHigher 
        { 
            get { return (this.flags & 0x01) == 0x01; } 
        }
        public bool DeviceIsSuperSpeedCapableOrHigher
        {
            get { return (this.flags & 0x02) == 0x02; }
        }
    }
