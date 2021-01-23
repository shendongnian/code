    public AddBar(Bar bar)
    {
        int index = 0;    
        foreach (bar b in AllBar)
        {
           if(bar.Duration < b.Duration)
             break;
           index++;
        }
        AllBars.Insert(index, bar);
    }
