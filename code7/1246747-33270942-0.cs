	const int max = 10;
	var loop = 0;
	using (var sdr = cmd.ExecuteReader())
	{
		var fieldcount = sdr.FieldCount;
		var getfi = new Func<int, FileInfo>(i =>
		{
			var fi = new FileInfo(String.Format(@"c:\temp\Multi_Files{0}.xlsx", i));
			if (fi.Exists) fi.Delete();
			return fi;
		});
		var savefile = new Action<FileInfo, List<Object[]>>((info, rows) =>
		{
			using (var pck = new ExcelPackage(info))
			{
				var wb = pck.Workbook;
				var ws = wb.Worksheets.Add("RESULTS");
				for (var row = 0; row < rows.Count; row++)
					for (var col = 0; col < fieldcount; col++)
						ws.SetValue(row + 1, col + 1, rows[row][col]);
				pck.Save();
			}
		});
		var rowlist = new List<Object[]>();
		while (sdr.Read())
		{
			var rowdata = new Object[sdr.FieldCount];
			sdr.GetValues(rowdata);
			rowlist.Add(rowdata);
			
			if (rowlist.Count == max)
			{
				savefile(getfi(++loop), rowlist);
				rowlist.Clear();
			}
		}
		if (rowlist.Count > 0)
			savefile(getfi(++loop), rowlist);
	}
