		var datatables =
			Directory
				.GetFiles(pathLocalSuccess)
				.Select(file => File.ReadAllLines(file).Select(x => x.Split('|')).ToArray())
				.Select(lines => new
				{
					headers = lines[0].Skip(1).ToArray(),
					lines = lines.Skip(1).Select(l => l.Skip(1).ToArray()).ToArray(),
				})
				.Select(x =>
				{
					var dt = new DataTable();
					foreach (var dc in x.headers)
					{
						dt.Columns.Add(new DataColumn(dc));
					}
					foreach (var line in x.lines.Skip(1).Where(y => y.Length == x.headers.Length))
					{
						var row = dt.NewRow();
						row.ItemArray = line;
						dt.Rows.Add(row);
					}
					return dt;
		  		})
				.ToArray();
