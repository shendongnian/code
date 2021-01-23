    protected override void OnBarUpdate()
    {
       // first remove all items more than 3 minutes old
       DateTime oldest = DateTime.Now - TimeSpan.FromMinutes(3);
       tovBull.RemoveAll(be => be.Time < oldest);
       // add the latest value
       tovBull.Add(new BarEvent(tovBullBar));
       //Find the minimum for the tovBull using linq
       double tovBullBarMin = tovBull.Min(be => be.Value);
      netLvtTOV = Math.Round((tovBearBar + tovBullBarMin + lvtBullBar)
      Print (Time.ToString()+" "+"ArrayLength:"+tovBull.Count);
    }           
