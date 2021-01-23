    /*STATS*/
    public void stats()
    {
      while (botrunning == true) {
        Thread.Sleep(10);
    
        SetText(HPLabel, Memory.SetCurrentHP());
      }
    }
