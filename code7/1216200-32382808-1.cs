    static void Main(string[] args)
            {
                var obj = new DeviceMonitorSignaling();
                Console.WriteLine("Starting...");
                obj.Start();
    
                Thread.Sleep(4000); // after 4 sec remove the device.
    
                Console.WriteLine("Changing device state.");
                obj.DisconnectDevice();
    
                Thread.Sleep(4000); // // after 4 sec change the device status.
                obj.ChangeDeviceState();
    
                Console.Read();
                Console.WriteLine("Stopping...");
    
                obj.Stop();
                Console.Read();
            }
