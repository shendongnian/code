    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(() => serialPort1_DataReceived(sender, e)));
        }
        else
        {
            var sp = sender as SerialPort;
            //this assumes you want the data from the arduino as text.  
            // you may need to decode it here.
            polestatusu.Text = sp.ReadExisting();
        }
    }
