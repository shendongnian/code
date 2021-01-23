	using (var pck = new ExcelPackage(existingFile))
	{
		var worksheet = pck.Workbook.Worksheets.First();
		//this is important to hold onto the range reference
		var cells = worksheet.Cells;
		//this is important to start the cellEnum object (the Enumerator)
		cells.Reset();
		//Can now loop the enumerator
		while (cells.MoveNext())
		{
            //Current can now be used thanks to MoveNext
			Console.WriteLine("Cell [{0}, {1}] = {2}"
				, cells.Current.Start.Row
				, cells.Current.Start.Column
				, cells.Current.Value);
		}
	}
