    public void PrepareHTML(dynamic data) 
    {
        StringBuilder SB = new StringBuilder("");
        TimeSpan time = StartTime; // Start/EndTime are `TimeSpan`s defined in another place
        
        // loop from StartTime to EndTime in 30 min increments
        while(time <= EndTime)
        {
            String t = String.Format(@"{0:hh\:mm}", time);
            var d = GetThisTime(time,data);
            if(d != null){
               SB.AppendFormat("<option value=\"{0}\">({1}) {0}</option>", t, d); // error is here: Cannot apply indexing with [] to an expression of type 'object'
           }
           else
           {
               SB.AppendFormat("<option value=\"{0}\">{0}</option>", t);
           }
            time = time.Add(Length);
        }
        H = SB.ToString();
    }
    public object GetThisTime(TimeSpan time, IEnumerable<dynamic> data)
    {
        return (from a in data
               where time = new TimeSpan(a.time)
               select a["count"]).FirstOrDefault();
    }
