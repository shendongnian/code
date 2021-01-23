    var resultSequence = copyFrom.Rows.Cast<DataRow>()
        .Select(row => new
        {
            Id = (string)row["oid"],
            Date = DateTime.Parse( (string) row["idate"]),
            Amount = Decimal.Parse (string) row["amount"]),
        })
        .GroupBy (itemToProcess => new
        {
            Id = item.Id,
            Data = item.Data
        });
        .Select(groupItem => new
        {
            Id = groupItem.Key.Id
            Date = groupItem.Key.Date,
            Sum = groupItem.Sum(itemToProcess => itemToProcess.Value,
        });
   
