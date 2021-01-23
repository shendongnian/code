    [Flags]
    public enum USB_PROTOCOLS : uint
    {
        Usb110 = 0x01,
        Usb200 = 0x02,
        Usb300 = 0x04,
    }
    
    [Flags]
    public enum USB_NODE_CONNECTION_INFORMATION_EX_V2_FLAGS : uint // nice short type name
    {
        DeviceIsOperatingAtSuperSpeedOrHigher = 0x01,
        DeviceIsSuperSpeedCapableOrHigher = 0x02,
    }
