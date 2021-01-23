            foreach(string key in retryList.Keys)
            {
                retryList[key] += 1; // <-- The error happens here ! Do not alter the Dictionary during an iteration
                if (retryList[key] > Retries)
                {
                    DiscoveredDevice device = Devices.Find(d => d.SerialNo == key);
                    if (device != null)
                    {
                        OnDeviceRemoved(device);
                        Devices.Remove(device);
                        retryList.Remove(key); // <-- The error could also happen here ! Do not alter the Dictionary during an iteration
                    }
                }
            }
