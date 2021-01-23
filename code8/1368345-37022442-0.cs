    private ManualResetEvent _goReceived = new ManualResetEvent(false); // Initialize as "not set"
    void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        RxString = serialPort.ReadLine();
        // DO NOT CALL DISPLAYTEXT IF YOU RECEIVE "GO" - THE MAIN THREAD IS BLOCKED!
        if (RxString.StartsWith("go"))
        {
            _goReceived.Set();
        }
        else
        {
            this.Invoke(new EventHandler(DisplayText));
        }
    }
    
    void DisplayText(object sender, EventArgs e)
    {  
        String RxString1 = RxString+("\n");
        if (RxString1 == "END\n") {
           stopauto = "stop";
           autostart.Enabled = true;
           autostop.Enabled = false;
        }
    }
