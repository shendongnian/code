    foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
        {
            try{
                SerialPort serialPort1 = new SerialPort();
                serialPort1.PortName = portName;
                serialPort1.Open();
                CommsBox.Items.Add(portName); //If you can open it it's because it was free, so we can add it to available
                serialPort1.Close(); //Should close it again
                }
            catch (Exception ex){
                //manage the exception...
            }
        }
