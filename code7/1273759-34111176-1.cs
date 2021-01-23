    CountryRatioCollection = new ObservableCollection<PiePointModel>();
    var groups = Customers.GroupBy(i => i.Country);     
    foreach(var gr in groups)
    {
        PiePointModel piePointModel = new PiePointModel()
        {
            Name = gr.Key,
            Amount = gr.Count()
        };
        CountryRatioCollection.Add(piePointModel);
    }
