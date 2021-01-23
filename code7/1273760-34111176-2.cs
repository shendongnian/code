    IEnumerable<PiePointModel> piePoints = Customers.GroupBy(i => i.Country).Select(s => new PiePointModel()
    { 
        Name = s.Key, 
        Amount = s.Count() 
    });
    CountryRatioCollection = new ObservableCollection<PiePointModel>(piePoints);
