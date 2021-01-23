    int dayspan = 5;
    
    var result = data.Select(
        delegate(History history, int index)
        {
            decimal[] vol = data
                    .Select((history1, index1) => new {History = history1, Index = index1})
                    .Where(x => x.Index <= index 
                        && index - x.Index < dayspan 
                        && x.History.Symbol == history.Symbol)
                    .Select(x => x.History.Close).ToArray();
            return new
            {
                Symbol = history.Symbol,
                Close = history.Close,
                Date = history.Date,
                Vol = vol.Count() == dayspan ? vol.Average() : 0
            };
        });
