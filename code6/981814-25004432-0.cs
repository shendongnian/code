     string[] availablePorts = SerialPort.GetPortNames();
            foreach (string strPortName in availablePorts)
            {
                try
                {
                    SerialPort SerialPort1 = new SerialPort(strPortName, 9600, Parity.None, 8, StopBits.One);
                    SerialPort1.Open();
                }
                catch (Exception e)
                {
                    //Print error to user
                }
            }
