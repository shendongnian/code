    try 
    {
        SerialPort SerialPort1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        SerialPort1.Open()
        SerialPort1.DataReceived += new SerialDataReceivedEventHandler(...)
    }
    catch(Exception e)
    {
        //Print error to user
    }
