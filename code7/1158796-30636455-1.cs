    var mainCatName; // Replace var with string.
    foreach (var rvItem in rvBrukItems)
        {
           mainCatName  = (await db.Categories.FirstAsync(n => n.Id == rvItem.MainCategoryId)).Name;
    
            if (!rvItem.TotalPerMonthImage.IsNullOrWhiteSpace() ||
                !rvItem.DifferentStoresImage.IsNullOrWhiteSpace() ||
                !rvItem.SubCategoryImage.IsNullOrWhiteSpace() ||
                !rvItem.TransactionsPerMonthImage.IsNullOrWhiteSpace() ||
                !rvItem.AverageTradeValueImage.IsNullOrWhiteSpace())
            {
               html.Append("<li class='list-level2'>" + mainCatName + "</li>");
            }
    }
