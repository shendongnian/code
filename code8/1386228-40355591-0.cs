    using (var mt = new ClrWrapper(new ConnectionParameters {Login = 0, Password = "", Server = "" }))
    {
        var symbols = mt.CfgRequestSymbol();
        mt.SymbolsRefresh();
        foreach (var symbol in symbols)
        {
            mt.SymbolAdd(symbol.Name);
        }
        mt.PumpingSwitchEx(PumpingMode.Default);
        mt.BidAskUpdated += (sender, args) =>
        {
            var total = 0;
            do
            {
                var symbolsInfos = mt.SymbolInfoUpdated();
                foreach (var symbolInfo in symbolsInfos)
                {                            
                    if (!symbolInfo.Symbol.All(char.IsLetter))
                    {
                        Console.WriteLine("{0} {1} {2}", DateTime.Now, symbolInfo.Symbol, symbolInfo.Bid);
                    }
                }
                total = symbolsInfos.Count;
            } while (total > 0);
        };
        Console.ReadKey();
    }
