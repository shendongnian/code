    public int Days
    {
        get {
    
            QuoteApp.Models.Quote ts = new QuoteApp.Models.Quote();
            ts.StartDate = StartDate;
            ts.EndDate = EndDate;
    
            int days;
            days = (EndDate.Day - StartDate.Day);
            return days;
        }
    }
