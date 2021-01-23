    timer1.Tick += tmr1_Tick;
    public void GetNewTurn(Turn turn)
    {
      _tmrStarTime = DateTime.Now;
      timer1.Start();
    }
