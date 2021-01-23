    public void OnLeScan(BluetoothDevice device, int rssi, byte[] scanRecord)
            {
                if (device.Name != null)
                {
                    EventScanDevice(device, rssi);                
                }
            }
