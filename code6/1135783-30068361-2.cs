    // get properties specified by "Keys" collection
        var properties = MembersProvider.GetProperties(typeof(Employee), Keys.ToArray());
    
        // Group and Select 
        var SalesSummary = Employees
            .GroupByKeys(Keys.ToArray())
            .Select(g =>
                properties.Aggregate(
                    new Dictionary<string, object>() { { "TotalSales", g.Select(employee => employee.Sales).Sum() } },
                    (dictionary, property) => {
                        dictionary.Add(property.Name, property.GetValue(g.FirstOrDefault(), null));
                        return dictionary;
                    }   
                )
            );
