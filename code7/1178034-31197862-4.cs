    DataTable table = manager.GetData("SELECT * FROM Shops");
    var shops = new List<Shop>();
    foreach (DataRow row in table.Rows)
    {
        shops.Add(new Shop
        {
            ShopName = row["ShopName"].ToString(),
            Fruit = row["Fruit"].ToString()
        });
    }
