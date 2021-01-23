    public void DoBoth(string symbol, double bid, double ask)
    {
        changeQuote(symbol,bid,ask);
        updateIndicators(symbol,bid,ask);
    }
    // ...
    var subscription =
        quoteUpdate
        .SubscribeOn(Scheduler.Default)
        .Subscribe (quote => this.DoBoth(quote.S, quote.B, quote.A));
