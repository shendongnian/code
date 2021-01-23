            var listDevices = bluetoothAdapter.BondedDevices;
            if (listDevices.Count > 0)
            {
                foreach (var btDevice in listDevices)
                {
                    if (btDevice.Name == "CONTROLLER")
                    {
                        UUID = btDevice.GetUuids().ElementAt(0);
                        deviceDictionary.Add(btDevice.Name, btDevice.Address);
                    }
                }
            }
