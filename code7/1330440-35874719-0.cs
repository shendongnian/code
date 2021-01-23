    if (flag)
    {
      Thread.MemoryBarrier();
      SendDataToExternalDevice();
      Thread.MemoryBarrier();
      System.Threading.Thread.Sleep(delayValue);
    }
    SendMoreDataToExternalDevice();
