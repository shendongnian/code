    public void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            arduino = new SerialPort(port);
            // you should specify these before opening the port
            arduino.DtrEnable = true;
            arduino.RtsEnable = true;
            arduino.BaudRate = 9600;
            // register to the event
            arduino.DataReceived += OnDataReceived;
            //open the port
            arduino.Open();
            // tell the user
            checkBox1.Text = "Listening...";
        }                
    }
