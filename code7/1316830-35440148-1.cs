    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(string));
    table.Columns.Add("Area", typeof(int));
    table.Columns.Add("Day1", typeof(double));
    table.Columns.Add("Day2", typeof(double));
    table.Columns.Add("Day3", typeof(double));
    table.Columns.Add("Day4", typeof(double));
    
    table.Rows.Add("a", 1, 0.1, 0.1, 0.1, 0.1);
    table.Rows.Add("b", 1, 0.1, 0.1, 0.1, 0.1);
    table.Rows.Add("c", 1, 0.1, 0.1, 0.1, 0.1);
    table.Rows.Add("d", 2, 0.1, 0.1, 0.1, 0.1);
    table.Rows.Add("e", 2, 0.1, 0.1, 0.1, 0.1);
    
    var result = table.AsEnumerable().Where (t => t.Field<int>("Area") == 1)
    								 .GroupBy (t => t.Field<int>("Area"))
    								 .Select(x => new {
    								    Area = x.Key,
    								 	Day1 = x.Sum (y => y.Field<double>("Day1")),
    									Day2 = x.Sum (y => y.Field<double>("Day2")),
    									Day3 = x.Sum (y => y.Field<double>("Day3")),
    									Day4 = x.Sum (y => y.Field<double>("Day4"))
    								 });
    result.Dump();
