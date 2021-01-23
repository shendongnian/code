    private void reinitRightPort(SerialPort sp){ //get SerialPort from outside of method
        //Add whatever necessary here, to close all the current connections
        //Plus all the error handlings
        if (sp == null) //Read 3.
            return;
        sp.Close(); //Read 4. close the current connections
        //get the right modbus data structure element
        ModBus MB = (ModBus)s[0].sensorData;
        //set up the serial port regarding the data structure's data
        sp = new SerialPort(); //Read 2. sp is from outside the method, but use new keyword still
        sp.PortName = MB.portName;
        sp.BaudRate = Convert.ToInt32(MB.baudRate);
        sp.DataBits = MB.dataBits;
        sp.Parity = MB.parity;
        sp.StopBits = MB.stopBits;
        //Set time outs 20 sec for now
        sp.ReadTimeout = 20000;
        sp.WriteTimeout = 20000;
        //portList.Add(sp); Read 1. no need to add this! It is already there!
        sp.Open();
    }
