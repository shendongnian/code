    private void Com_Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            char val;
            try
            {
                SerialPort sp = (SerialPort)sender;
                string data = sp.ReadExisting();
                val=Your_method_to_process_string(data);
                label6.Text = Convert.ToString(val);
            }
            catch (Exception) { }
        }
