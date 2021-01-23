    List<string> scanList;
    private void Scanner_EventScanDevice(BluetoothDevice device, int rssi)
    {
     if (!scanList.Contains(device.Name))
     {
          scanList.Add(device.Name + ",RSSI = " + rssi.ToString());
                  
     }
    }
