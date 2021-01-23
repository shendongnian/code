    int dayspan = 5;
    var result = from history in data
        let lastCloses =
                from history1 in data
                where history.Symbol == history1.Symbol 
                    && history.Date >= history1.Date 
                    && history.Date - history1.Date <= TimeSpan.FromDays(dayspan)
                select history1.Close
        select new {
            Symbol = history.Symbol, 
            Close = history.Close, 
            Date = history.Date, 
            Vol = lastCloses.Count() >= dayspan ? lastCloses.Average() : 0};
