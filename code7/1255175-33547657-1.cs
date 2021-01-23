    foreach(PriceList pl in priceLists)
    {
        columns.Add(new ColumnDescriptor 
                   { HeaderText = pl.Name, 
                     DisplayMember = "Prices[" + priceLists.IndexOf(pl) +  "].Price" });
    }
