    using System;
    using Windows.Devices.Bluetooth.Advertisement;
    
    namespace WindowsIoTCorePi2FezHat
    {
        internal class BleTagWatcher
        {
            private ulong tagNo;
            private BluetoothLEAdvertisementWatcher watcher;
    
            private const short OutOfRange = -127;
            private short rssi;
            private DateTime lastDetected;
    
            public BleTagWatcher(ulong v)
            {
                this.tagNo = v;
                Rssi = OutOfRange;
    
                watcher = new BluetoothLEAdvertisementWatcher { ScanningMode = BluetoothLEScanningMode.Active };
                watcher.Received += OnAdvertisementReceipt;
                watcher.Stopped += (s, a) => { Rssi = OutOfRange; };
                watcher.Start();
            }
    
            private void OnAdvertisementReceipt(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
            {
                if (args.BluetoothAddress == tagNo)
                    Rssi = args.RawSignalStrengthInDBm;
            }
    
            public short Rssi
            {
                get
                {
                    //if (lastDetected.AddSeconds(20) < DateTime.Now)
                    //    return OutOfRange;
                    return rssi;
                }
                set
                {
                    rssi = value;
                    lastDetected = DateTime.Now;
                }
            }
        }
    }
