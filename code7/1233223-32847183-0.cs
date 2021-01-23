    var products = new DataTable();
	products.Columns.Add("ProductName", typeof(string));
	products.Columns.Add("Qty1", typeof(int));
	products.Columns.Add("Qty2", typeof(int));
	products.Columns.Add("Qty3", typeof(int));
	
	products.Rows.Add(new object[] {"A", 2, 0, 4});
	products.Rows.Add(new object[] {"A", 0, 4, 5});
	products.Rows.Add(new object[] {"A", 3, 2, 0});
	products.Rows.Add(new object[] {"B", 5, 4, 2});
	products.Rows.Add(new object[] {"C", 6, 4, 3});
	products.Rows.Add(new object[] {"C", 1, 1, 1});
	
	products.AsEnumerable()
			.GroupBy (p => p.Field<string>("ProductName"))
			.Select (p => new {
				Name = p.Key,
				Qty1 = p.Sum (a => a.Field<int>("Qty1")),
				Qty2 = p.Sum (a => a.Field<int>("Qty2")),
				Qty3 = p.Sum (a => a.Field<int>("Qty3"))
			});
