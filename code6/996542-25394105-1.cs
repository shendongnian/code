    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string inData = serialPort1.ReadLine();
        if (PauseButton.Text == "Pause" && inData.StartsWith("<"))
        {
            _queue.Enqueue(inData);
        }
    }
