    protected virtual void OnTradeCalledBack(TposTradeCallback trade)
    {
        if (TradeCalledBack != null)
        {
            TradeCalledBack(trade);
        }
    }
