    var productList = datatable.Rows.Cast<DataRow>()
        .GroupBy(r => r["Category"] + "").Select(g => new ProductListModel {
            CategoryName = g.Key,
            prodList = g.Select(r => new ProductModel {
                Name = r["Name"] + "",
                Amount = (double)r["Amount"]
            }).ToList()
        }).ToList();
