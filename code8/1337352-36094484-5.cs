    protected async Task<string> GetBitcoinPrice()
    {
        IPriceRetrieve bitcoin = new BitcoinPrice();
        string price = await bitcoin.GetStringPrice();
        return price;
    }
