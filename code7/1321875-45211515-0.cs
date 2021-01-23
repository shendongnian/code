    using System.Threading;
    public void main()
    {
        setup();
        Thread readThread = new Thread(Read);
        readThread.Start();
    }
    public void Read()
    {
        while(true)
        {
        try
        {
            string message = serialPort1.ReadLine();
        }
        catch (Exception)
        { }
    }
