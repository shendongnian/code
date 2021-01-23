    public SerialPort sp;
    string dataReceived = string.Empty;
    private delegate void SetTextDeleg(string text);
    private void FormLoad()
    {
     sp = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
     this.sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
     sp.Open();
    }
    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
     try
     {
          Thread.Sleep(500);
           string x = sp.ReadLine(); // will read to the first carriage return
           this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { x });
      }
      catch
      { }
    }  
    private void si_DataReceived(string data)
    {
      dataReceived = data.Trim();
      // Do whatever with the data that is coming in.
    }
