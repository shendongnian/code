    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           string inData = serialPort1.ReadLine();
           System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ProcessData));
           T.Start(inData);
    }
    public void ProcessData(Object data)
    {
    ....
    }
