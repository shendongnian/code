    // 1. Query for all data we need
    var pivotInput = db.TotalPurchases
        .GroupBy(p => p.Country)
        .Select(cp => new {
                Country = cp.Key,
                PurchasesByCity = cp.GroupBy(x => x.City).Select(c => new {
                    City = c.Key,
                    NumberOfPurchases = c.Count()
                })
            }).ToList();
    // 2. Get all distinct cities
    var allCities = pivotInput
        .SelectMany(x => x.PurchasesByCity.Select(c => c.City))
        .Distinct().ToList();
    // 3. Build the pivot data table "schema".
    var pivotTable = new DataTable("purchasesByCity");
    pivotTable.Columns.Add(new DataColumn("Country", typeof(string)));
    allCities.ForEach(c => pivotTable.Columns.Add(new DataColumn(c, typeof(int))));
    // 4. Add as rows to the datatable
    foreach (var c in pivotInput)
    {
        var row = pivotTable.NewRow();
        row["Country"] = c.Country;
        foreach (var city in c.PurchasesByCity)
            row[city.City] = city.NumberOfPurchases;
        pivotTable.Rows.Add(row);
    }
