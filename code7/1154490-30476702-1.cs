    var sample = "2Y 4M 3D";
    var split = sample.Split(' ');
    
    DateTime prevDate, nextDate, now;
    prevDate = nextDate = now = DateTime.Now;
    
    foreach (var sp in split)
    {
        var d = Regex.Match(sp, @"\d+").Value;
        var t = Regex.Match(sp, @"[A-Z]+").Value;
    
        switch(t)
        {
            case "Y":
                {
                    prevDate = prevDate.AddYears(-int.Parse(d));
                    nextDate = nextDate.AddYears(int.Parse(d)); 
                    break;
                }
            case "M":
                {
                    prevDate = prevDate.AddMonths(-int.Parse(d)); 
                    nextDate = nextDate.AddMonths(int.Parse(d)); 
                    break;
                }
            case "D":
                {
                    prevDate = prevDate.AddDays(-int.Parse(d)); 
                    nextDate = nextDate.AddDays(int.Parse(d)); 
                    break;
                }
        }
    }
    
    var timeSpanPrev = now - prevDate;
    var timeSpanNext = nextDate - now;
