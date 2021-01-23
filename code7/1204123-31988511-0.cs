    string Condition(string cond) 
    {
        switch(cond)
        {
            case "Insulated":
                return "SCH095";
               ...
        }
    }
    StockItem = db.StockItems.Where(x => x.StockCode == Condition(quoteItem.BodyType.Name)).First();
