    foreach(PriceList pl in priceLists)
    {
        colums.Add(new ColumnDescriptor
                   { HeaderText = pl.Name, DisplayMember = "Prices.Price" });
    }
