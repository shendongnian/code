    // Group the data out of your model organized by the SomeProperty value
    // Order it by the number of items in the list so we know the first group will have the maximum number of values we'd need
    var orderedGroups = Model.Items
        .SelectMany(itm => itm.ItemLines)
        .GroupBy(itm => itm.SomeProperty)
        .OrderByDescending(grp => grp.Count());
    // Find out how many ItemLines you'd want to have in any 1 Item
    var count = orderedGroups.First().Count();
    // Create the output
    var output = new Order() { 
                    Items = orderedGroups
                    .Select(grp => 
                        new Item() 
                        {
                            ItemLines = new ItemLine[count]
                            .Select((s,i) => grp.ElementAtOrDefault(i) ?? new ItemLine())
                        }
                    )};
