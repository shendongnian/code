    /*STATS*/
    public void stats()
    {
      while (botrunning == true) {
        Thread.Sleep(100);
    
        SetText(HPLabel, Memory.SetCurrentHP());
      }
    }
