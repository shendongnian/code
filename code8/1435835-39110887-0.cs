    Using System.IO.Ports;
    Using System.Managment;
    Using System;
    private void SetPort()
        {
            string[] allPorts = SerialPort.GetPortNames();
            bool found = false;
            SerialPort port;
            for (int i = 0; i < allPorts.Length; i++)
            {
                var searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSSerial_PortName");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string instanceName = queryObj["InstanceName"].ToString();
                    if (instanceName.IndexOf("Your Modem String", StringComparison.Ordinal) > -1)
                    {
                        string portName = queryObj["PortName"].ToString();
                        port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
        }
