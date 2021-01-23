    UInt32 numBytesAvailable = 0;
    
    while (true)
    {
        ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
        if (ftStatus != FTDI.FT_STATUS.FT_OK)
        {
            Console.WriteLine("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
            Console.ReadKey();
            break;
        }
    
        string readData = "";
        UInt32 numBytesRead = 0;
        byte[] dataBuffer = new byte[1024];    
        
        // TODO: check so you don't over your buffer.
        ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);
        
        ProcessData(readData);
        
        Thread.Sleep(10000); // Sleep 10 seconds.
    }
