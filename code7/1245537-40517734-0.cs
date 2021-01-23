        static bool SetClientAudioDevice(LyncClient client, string name)
        {
            var innerClient = (ILyncClient)client.InnerObject;
            var deviceManager = innerClient.DeviceManager;
            Console.WriteLine("Current audio device: [{0}]", client.DeviceManager.ActiveAudioDevice.Name);
            Console.WriteLine("Lync Client Audio Devices List:");
            var ok = false;
            foreach (var device in deviceManager.AudioDevices.OfType<Microsoft.Office.Uc.AudioDevice>())
            {
                Console.WriteLine("    AudioDevice: [{0}], Active[{1}], ID[{2}], IsCertified[{3}], Priority[{4}], Type[{5}]", device.Name, device.IsActive, device.Id, device.IsCertified, device.Priority, device.Type);
                if (device.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Console.WriteLine("        Setting active device!");
                    deviceManager.ActiveAudioDevice = device;
                    ok = true;
                }
            }
            return ok;
        }
