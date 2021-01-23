    var displayDataAmalgamated =
    	new[] { craftworksPVDList, chophousePVDList, gordonbierschPVDList, oldchicagoPVDList, oldchifranchisePVDList, rockbottomPVDList }
    	.SelectMany(list => list.Select(item => new { item.ShortName, item.ItemCode, item.Description }))
    	.Distinct()
    	.Select(item => new PriceVarianceSupersetDisplayData { ShortName = item.ShortName, ItemCode = item.ItemCode, Description = item.Description })
    	.OrderBy(item => item.ShortName).ThenBy(item => item.ItemCode)
    	.ToList();
