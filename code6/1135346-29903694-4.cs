    var notUsed = this.Numbers.Where(used => !used)
                     .Select((val, idx) =>
                          new 
                          {
                              Idx = idx,
                              Val = val
                          }).ToList();
    
    if (!notUsed.Any())
    {
        //case when all numbers used
    }
    else
    {
        attempt = notUsed[this.r.Next(0, notUsed.Count)].Idx;
        this.Numbers[attempt] = true;
    }
