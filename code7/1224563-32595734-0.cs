    System.Threading.Thread t = new System.Threading.Thread(delegate()
    {
        try
        {
            DateTime cmdStartTime = DateTime.UtcNow;
            instrument = programmer.GetInstrument(_address);
            DateTime cmdEndTime = DateTime.UtcNow;
            TimeSpan totalCmdRuntime = cmdEndTime - cmdStartTime;
            Debug.WriteLine(String.Format("Programmer.GetInstrument({0}) command took {1} mSec to execute", _address, totalCmdRuntime.TotalMilliseconds));
        }
        catch { }
    });
    t.Name = "GetInstrumentTimer";
    t.Start();
