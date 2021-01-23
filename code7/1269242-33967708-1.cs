    foreach (string s in stringItems)
    {
        PriceList pl = new PriceList () { itemDescription = s, listDate = today, listPrice = price, theVolume = volume };
        items.Add (pl);
    }
