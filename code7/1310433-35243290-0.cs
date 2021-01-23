    Stream str = //...
    Timer tmr = new Timer((o) => str.Close());
    tmr.Change(yourTimeout, Timeout.Infinite);
    byte[] data = new byte(1024);
    bool success = true;
    try{  str.Read(data, 0, 1024);  }
    catch{ success = false, }
    finally{ tmr.Change(Timeout.Inifinite, Timeout.Infinite); }
    if(success)
       //read ok
    else
       //read timeout
