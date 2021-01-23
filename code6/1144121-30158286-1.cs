    using(var str = await GetWriteStreamAsync("path", "text/plain"))
    using(var csvFile = new StreamWriter(str))
    {
        for (int i = 1; i <= recId; ++i)
        {
            Ad ad = db.Ads.Find(i);
            if (ad != null)
            {
                string rec = String.Format("{0}, {1}, {2}, {3}, {4}", ad.Title, ad.Category, ad.Price, ad.Description, ad.Phone);
                csvFile.WriteLine(rec);
            }
        }
        csvFile.Flush();
    }
