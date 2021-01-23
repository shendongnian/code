    [BroadcastReceiver(Enabled=true,Exported=true,Permission="android.permission.USB_PERMISSION")]
    [UsesLibrary("android.hardware.usb.host", Required = true)]
    [MetaData("android.hardware.usb.action.USB_DEVICE_ATTACHED", Resource = "@xml/device_filter")]
    [MetaData("android.hardware.usb.action.USB_DEVICE_DETACHED", Resource = "@xml/device_filter")]
    [IntentFilter(new string[] { "android.hardware.usb.action.USB_DEVICE_ATTACHED", "android.hardware.usb.action.USB_DEVICE_DETACHED" })]
    public class UsbBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent != null) Log.Debug("testusb", string.Format("OnReceive - {0} ", intent.Action));            
        }
    }
