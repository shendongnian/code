    #include <usbioctl.h>
    
    int size = sizeof(USB_PROTOCOLS); // size = 4
    USB_PROTOCOLS proto = { 0 }; 
    proto.Usb110 = 1;
    unsigned int val = *((unsigned int*)(&proto)); // val = 1
    proto.Usb110 = 0;
    proto.Usb200 = 1;
    val = *((unsigned int*)(&proto)); // val = 2
    proto.Usb200 = 0;
    proto.Usb300 = 1;
    val = *((unsigned int*)(&proto)); // val = 4
    
    size = sizeof(USB_NODE_CONNECTION_INFORMATION_EX_V2_FLAGS); // size = 4
    USB_NODE_CONNECTION_INFORMATION_EX_V2_FLAGS flags = { 0 };
    flags.DeviceIsOperatingAtSuperSpeedOrHigher = 1;
    val = *((unsigned int*)(&flags)); // val = 1
    flags.DeviceIsOperatingAtSuperSpeedOrHigher = 0;
    flags.DeviceIsSuperSpeedCapableOrHigher = 1;
    val = *((unsigned int*)(&flags)); // val = 2
