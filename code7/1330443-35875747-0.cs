    int delay = 0;
    if (flag)
    {
      SendDataToExternalDevice();
      delay = delayValue;
    }
    var timer = new System.Threading.Timer(_ => SendMoreDataToExternalDevice()
          ,null
          ,delay
          ,Timeout.Infinite);
