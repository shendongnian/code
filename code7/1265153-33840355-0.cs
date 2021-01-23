	var dt = new DataTable();
	dt.Columns.Add("EmpID", typeof(int));
	dt.Columns.Add("EmpName", typeof(string));
	var dr = dt.NewRow();
	dr.ItemArray = new object[] { 1, "John" };
	dt.Rows.Add(dr);
	dr = dt.NewRow();
	dr.ItemArray = new object[] { 2, "Doe" };
	dt.Rows.Add(dr);
	dr = dt.NewRow();
	dr.ItemArray = new object[] { 3, "Mary" };
	dt.Rows.Add(dr);
	var query =
		dt
			.AsEnumerable()
			.Select(x => String.Format(
				"EmpID: {0} EmpName: {1}",
				x.Field<int>(0),
				x.Field<string>(1)))
			.ToList();
