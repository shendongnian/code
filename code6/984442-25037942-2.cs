    public void SetCommand(SerialPortComm sp, string command)
    {
       Task.Factory.StartNew( () => {
          sp.SetStringDataFromControl(sp.mySerialPort, command); 
     });
    }
