    async Task<int> AlgoSendOrderAsync(MT4Order order)
    {
        int retVal = -1;
        //Doing this on another thread using Task.Run
        await Task.Run(() =>
        {
            retVal = apiClient.OrderSend(order.Symbol, (TradeOperation)order.OrderSide, order.Volume,
                                        order.Price, order.AllowedSlippage ?? default(int),
                                        order.PriceToStopLoss ?? default(double),
                                        order.PriceToTakeProfit ?? default(double));
        });
        return retVal;
    }
