    void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
       var expr = "\\+ [0-9]+\\.[0-9]+";
       var newVal = _serialPort.ReadExisting();
       MatchCollection mc = Regex.Matches(newVal, expr);
       if (mc.Count > 0)
       {
          if(String.Compare(txtWeight.Text, mc[0].Value) != 0)
             txtWeight.Text = mc[0].Value;
       }
    }
