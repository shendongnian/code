    using (arduino = new SerialPort(port))
    {
        arduino.Open();
        arduino.DtrEnable = true;
        arduino.RtsEnable = true;
        arduino.BaudRate = 9600;
        arduino.DataReceived += OnDataReceived; //when data is received, call method below.
        //System.Windows.Forms.Application.Exit(); //this works, which means the above line has been run too.
    }
