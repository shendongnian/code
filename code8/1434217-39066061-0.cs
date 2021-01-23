    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            checkBox1.Text = "Listening...";
            using(SerialPort arduino = new SerialPort())
            {
               arduino.BaudRate = 9600;
               arduino.PortName = comboBox1.Text;
               string pipe;
               arduino.Open();
               pipe = arduino.ReadLine();
               if (pipe == "S\r")
               {
                    
                    //System.Diagnostics.Process.Start("shutdown", "/f /r /t 0");
                    //System.Windows.Forms.Application.Exit();
               }
           } // Here the port will be closed and disposed.
        }
        else
        {
            checkBox1.Text = "Start";
        }
    }
