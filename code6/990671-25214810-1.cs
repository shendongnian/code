	class Program
	{
		static void Main(string[] args)
		{
			var table = new DataTable();
			table.Columns.Add("Column1");
			table.Columns.Add("Column2");
			table.Rows.Add(new[] { "col1row1", "col2row1" });
			table.Rows.Add(new[] { "col1row2", "col2row2" });
			var strings = table.Columns["Column2"].GetDataInColumn();
			strings.ToList().ForEach(s => Console.WriteLine(s));
			Console.ReadLine();
		}
	}
    //Will output
    //col2row1
    //col2row2
