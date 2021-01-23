    var results = db.Stocks
                    .If(option != "0", stocks => stocks
                        .IfChain(option == "BelowMin", optionStocks => optionStocks
                            .Where(stock => stock.Qty < stock.Item.AlertQty))
                        .Else(optionStocks => optionStocks
                            .Where(stock => stock.Qty == stock.InitialQty)))
                    .WhereIf(!string.IsNullOrWhiteSpace(batch), stock => stock.BatchNo == batch)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), stock => stock.Item.Name.StartsWith("" + name + ""))
                    .ToList();
    return results;
