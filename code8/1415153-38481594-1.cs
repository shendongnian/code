    private void ComPort_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
    {
      recievedData = ComPort.ReadExisting(); //read all available data in the receiving buffer.
    
      if (InvokeRequired)
      {
        // If not on UI thread, then invoke
        Invoke(new MethodInvoker(() =>
        {
          // Show in the terminal window 
          rtxtDataArea.ForeColor = Color.Green; // error , 
          rtxtDataArea.AppendText(recievedData + "\n");
        }));
      }
      else
      {
        // On UI thread, invoke not needed
        // Show in the terminal window 
        rtxtDataArea.ForeColor = Color.Green; // error , 
        rtxtDataArea.AppendText(recievedData + "\n");
      }
    }
