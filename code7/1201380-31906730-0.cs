    private static IEnumerable<Tuple<decimal, IEnumerable<Transaction>>> ApplyGrouping(IEnumerable<Transaction> transactions){
        decimal runningTotal = 0m;
        decimal threshold = 10m;
        var grouped = new List<Transaction>();
        foreach(var t in transactions){
            grouped.Add(t);
            runningTotal += t.Amount;
            if (runningTotal <= threshold) continue;
            yield return new Tuple<decimal, IEnumerable<Transaction>>(runningTotal, grouped);
            grouped = new List<Transaction>();
            runningTotal = 0;
        }
    }
