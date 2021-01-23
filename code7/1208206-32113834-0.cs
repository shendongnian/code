    var myStockItem = quoteItem.BodyType.Name == "Royal Corrugated" || quoteItem.BodyType.Name == "Royal Smooth Riveted" ? db.StockItems.Where(x => x.StockCode == "AEX165").First() : null;
    
    if(myStockItem != null)
    {
        var qisg = new QuoteItemSectionGroup
        {
            SectionGroup = db.SectionGroups.Where(x => x.Name == "Ali Bottom Rail" && x.Section == TruckSection.FrontEndRequirments).First(),
            //StockItem is set here
            StockItem = myStockItem,
        };
        qisg.Quantity = qisg.StockItem == null ? 0 : 1;
        qisg.Weight = Math.Round(((double)qisg.Length * (double)qisg.Quantity) * (double)qisg.StockItem.Mass, 2);
        qisg.Cost = Math.Round(((double)qisg.Length * (double)qisg.Quantity) * (double)qisg.StockItem.UnitCost, 2);
        quoteItem.SectionGroups.Add(qisg);
    }
