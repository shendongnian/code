    foreach (var item in results)
    {
        var row = dt.AsEnumerable().FirstOrDefault(x => (int)x["ProductId"] == item.Id);
        int quantity = item.Quantity;
    
        if (row == null)
        {
            row = dt.NewRow();
            row.SetField("Quantity", quantity);
            row.SetField("ProductId", item.Id);
            dt.Rows.Add(row);
        }
        else
        {
            quantity += (int)row["Quantity"];
            row.SetField("Quantity", quantity);
        }
    }
