    public static class ExcelExporter
    {
    	public static void ExportDataTable(DataTable table, SheetData data)
    	{
    		var cellFactory = new CellFactory[table.Columns.Count];
    		for (int i = 0; i < table.Columns.Count; i++)
    			cellFactory[i] = GetCellFactory(table.Columns[i].DataType);
    		int rowIndex = 0;
    		data.AppendChild(CreateHeaderRow(rowIndex++, table));
    		for (int i = 0; i < table.Rows.Count; i++)
    			data.AppendChild(CreateContentRow(rowIndex++, table.Rows[i], cellFactory));
    	}
    	private static Row CreateHeaderRow(int rowIndex, DataTable table)
    	{
    		var row = CreateRow(rowIndex);
    		for (int i = 0; i < table.Columns.Count; i++)
    		{
    			var cell = CreateTextCell(i, rowIndex, table.Columns[i].ColumnName);
    			row.AppendChild(cell);
    		}
    		return row;
    	}
    	private static Row CreateContentRow(int rowIndex, DataRow dataRow, CellFactory[] cellFactory)
    	{
    		var row = CreateRow(rowIndex);
    		for (int i = 0; i < dataRow.Table.Columns.Count; i++)
    		{
    			var cell = cellFactory[i](i, rowIndex, dataRow[i]);
    			row.AppendChild(cell);
    		}
    		return row;
    	}
    	private static Row CreateRow(int index) { return new Row { RowIndex = (uint)index + 1 }; }
    	private delegate Cell CellFactory(int columnIndex, int rowIndex, object cellValue);
    	private static CellFactory GetCellFactory(Type dataType)
    	{
    		CellFactory factory;
    		return CellFactoryMap.TryGetValue(dataType, out factory) ? factory : TextCellFactory;
    	}
    	private static readonly CellFactory TextCellFactory = CreateTextCell;
    	private static readonly CellFactory DateCellFactory = CreateDateCell;
    	private static readonly CellFactory NumericCellFactory = CreateNumericCell;
    	private static readonly CellFactory BooleanCellFactory = CreateBooleanCell;
    	private static readonly Dictionary<Type, CellFactory> CellFactoryMap = new Dictionary<Type, CellFactory>
    	{
    		{ typeof(bool), BooleanCellFactory },
    		{ typeof(DateTime), DateCellFactory },
    		{ typeof(byte), NumericCellFactory },
    		{ typeof(sbyte), NumericCellFactory },
    		{ typeof(short), NumericCellFactory },
    		{ typeof(ushort), NumericCellFactory },
    		{ typeof(int), NumericCellFactory },
    		{ typeof(uint), NumericCellFactory },
    		{ typeof(long), NumericCellFactory },
    		{ typeof(ulong), NumericCellFactory },
    		{ typeof(float), NumericCellFactory },
    		{ typeof(double), NumericCellFactory },
    		{ typeof(decimal), NumericCellFactory },
    	};
    	private static Cell CreateTextCell(int columnIndex, int rowIndex, object cellValue)
    	{
    		return CreateCell(CellValues.String, columnIndex, rowIndex, ToExcelValue(cellValue));
    	}
    	private static Cell CreateDateCell(int columnIndex, int rowIndex, object cellValue)
    	{
    		// NOTE: CellValues.Date is not supported in older Excel version.
    		// In all Excel versions dates can be stored with CellValues.Number and a format style.
    		// Since I have no styles, will export them just as text
    		//var cell = CreateCell(CellValues.Number, columnIndex, rowIndex, ToExcelDate(cellValue));
    		//cell.StyleIndex = ...;
    		//return cell;
    		return CreateCell(CellValues.String, columnIndex, rowIndex, 
    			cellValue != null && cellValue != DBNull.Value ? ((DateTime)cellValue).ToShortDateString() : null);
    	}
    	private static Cell CreateNumericCell(int columnIndex, int rowIndex, object cellValue)
    	{
    		return CreateCell(CellValues.Number, columnIndex, rowIndex, ToExcelValue(cellValue));
    	}
    	private static Cell CreateBooleanCell(int columnIndex, int rowIndex, object cellValue)
    	{
    		// NOTE: CellValues.Boolean is not supported in older Excel version
    		//return CreateCell(CellValues.Boolean, columnIndex, rowIndex, ToExcelValue(cellValue));
    		return CreateCell(CellValues.String, columnIndex, rowIndex, ToExcelValue(cellValue));
    	}
    	private static Cell CreateCell(CellValues dataType, int columnIndex, int rowIndex, string cellValue)
    	{
    		var cell = new Cell();
    		if (dataType != CellValues.Number) cell.DataType = dataType;
    		cell.CellReference = GetColumnName(columnIndex) + (rowIndex + 1);
    		cell.CellValue = new CellValue(cellValue ?? string.Empty);
    		return cell;
    	}
    	private static string ToExcelValue(object value)
    	{
    		if (value == null || value == DBNull.Value) return null;
    		return Convert.ToString(value, CultureInfo.InvariantCulture);
    	}
    	private static DateTime ExcelBaseDate = new DateTime(1900, 1, 1);
    	private static string ToExcelDate(object value)
    	{
    		const int days29Feb1900 = 59;
    		if (value == null || value == DBNull.Value) return null;
    		var date = ((DateTime)value).Date;
    		var days = (date - ExcelBaseDate).Days + 1;
    		if (days >= days29Feb1900) days++;
    		return days.ToString(CultureInfo.InvariantCulture);
    	}
    	private static string GetColumnName(int index) { return ColumnNameTable[index]; }
    	private static readonly string[] ColumnNameTable = BuildColumnNameTable();
    	private static string[] BuildColumnNameTable()
    	{
    		var table = new string[16384];
    		var sb = new StringBuilder();
    		for (int i = 0; i < table.Length; i++)
    			table[i] = sb.BuildColumnName(i);
    		return table;
    	}
    	private static string BuildColumnName(this StringBuilder sb, int index)
    	{
    		const int startLetter = 'A';
    		const int letterCount = 'Z' - startLetter + 1;
    		sb.Clear();
    		while (true)
    		{
    			var letter = (char)(startLetter + (index % letterCount));
    			sb.Insert(0, letter);
    			if (index < letterCount) break;
    			index = (index / letterCount) - 1;
    		}
    		return sb.ToString();
    	}
    }
