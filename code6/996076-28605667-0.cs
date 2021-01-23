    private InTheHand.Net.Sockets.BluetoothClient _BTClient = null;
    private InTheHand.Net.Sockets.BluetoothDeviceInfo[] _clientDevices;
        /// <summary>
        /// Thread function to discover devices
        /// </summary>
        private void DiscoverBluetoothThread()
        {
            try
            {                                
                _BTClient = new InTheHand.Net.Sockets.BluetoothClient();
                _clientDevices = _BTClient.DiscoverDevices(999, _authenticated, _remembered, _unknown);
                _BTClient.Dispose();
                _BTClient = null;
            }
            catch (Exception) { }
          
        }
		
		
		Private void Connect(InTheHand.Net.Sockets.BluetoothDeviceInfo info)
		{
			string addressN = info.DeviceAddress.ToString("N"); //Format Example: "00066606E014"
            string addressC = info.DeviceAddress.ToString("C"); //Format Example: "00:06:66:06:E0:14"
            string addressP = info.DeviceAddress.ToString("P"); //Format Example: "00.06.66.06.E0.14"
            string addressD = info.DeviceAddress.ToString();    //Format Example: "00066606E014"
			
			string serialPort = FindBluetoothPortName(addressN);
			//http://stackoverflow.com/questions/26439091/how-to-get-bluetooth-device-com-serial-port-in-winform-c/27919129#27919129
			
			if (string.IsNullOrEmpty(serialPort) == false && serialPort.Trim().Length > "COM".Length)
				bool installed = InstallBluetoothDevice(addressC, passKey, autoConnect);
		}
		
		
		 public bool InstallBluetoothDevice(string deviceMACAddress, string passKey, bool connect)
         {
            string strDevicePassKey = passKey;
            string BTMac = deviceMACAddress;
            InTheHand.Net.BluetoothAddress BTAddress;
            InTheHand.Net.Sockets.BluetoothClient BTClient = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.BluetoothEndPoint BTEndPoint;
            InTheHand.Net.Bluetooth.BluetoothRadio BTRadio;
            BTRadio = InTheHand.Net.Bluetooth.BluetoothRadio.PrimaryRadio;
            BTRadio.Mode = RadioMode.Connectable;
            
            Guid spguid = BluetoothService.SerialPort;
            BTAddress = InTheHand.Net.BluetoothAddress.Parse(BTMac);
            BTEndPoint = new InTheHand.Net.BluetoothEndPoint(BTAddress, spguid);            
            try
            {
                BluetoothSecurity.PairRequest(BTAddress, strDevicePassKey);
                //Application.DoEvents();
                BTClient = new InTheHand.Net.Sockets.BluetoothClient();
                
                if (connect)
                {
                    BTClient.Connect(BTEndPoint);
                    BTEndPoint = new InTheHand.Net.BluetoothEndPoint(BTAddress, spguid);
                    _connectedDevices.Add(BTAddress, BTClient);
                    return BTClient.Connected;
                }
                            
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
