    var ordersById = doc.Descendants("orderItem")
        .GroupBy(x => (string) x.Element("OrderId")); // 1
    foreach (var grouping in ordersById)
    {
        var total = grouping
            .Sum(x => (decimal) x.Element("amount")); // 2
        grouping.First().SetElementValue("amount", total); // 3
        grouping.Skip(1).Remove(); // 4
    }
