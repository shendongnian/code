    public DesktopTickers(List<string> tickerArgs)
    {
        for (var i = 0; i < tickerArgs.Count; ++i)
        {
            var tickerArg = tickerArgs[i];
            var ticker = new Ticker(...);
            //your whole initialization code goes here
            //replace all "tickers[i]" with "ticker"
            ticker.Show();
        }
    }
