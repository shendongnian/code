    public class ExcelHelper
    {
    	public static MemoryStream TemplateFile { get; set; }
    	public static MemoryStream TemplateFileEn { get; set; }
    
    	private static string[] ColumnsNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    
    	//todo: change
    	private const string TemplateFilePath =
    		@"\App_Data\TemplateFiles\Fax-ArchiveReport.xlsx";
    	private const string TemplateFileEnPath =
    		@"\App_Data\TemplateFiles\Fax-ArchiveReport-en.xlsx";
    
    	public class ExcelData
    	{
    		public string SheetName { get; set; }
    		public List<string> Headers { get; set; }
    		public List<List<string>> Rows { get; set; }
    		public bool IsEn { get; set; }
    		public string Title { get; set; }
    	}
    
    	public static byte[] GenerateExcelV2(ExcelData data)
    	{
    		try
    		{
    			var root = HttpContext.Current.Server.MapPath("~");
    			
    			using( MemoryStream file = new MemoryStream() )
    			{
    			if (data.IsEn)
    			{
    				if (TemplateFileEn == null)
    				{
    					TemplateFileEn = new MemoryStream();
    
    					using (var stream = File.Open(root + TemplateFileEnPath, FileMode.Open))
    					{
    						stream.CopyTo(TemplateFileEn);
    					}
    
    				}
    
    				TemplateFileEn.Position = 0;
    				TemplateFileEn.CopyTo(file);
    			}
    			else
    			{
    				if (TemplateFile == null)
    				{
    					TemplateFile = new MemoryStream();
    
    					using (var stream = File.Open(root + TemplateFilePath, FileMode.Open))
    					{
    						stream.CopyTo(TemplateFile);
    					}
    				}
    
    				TemplateFile.Position = 0;
    				TemplateFile.CopyTo(file);
    			}
    			
    			var result = UpdateCells(file, data.Title, data.Headers, data.Rows);
    			
    			}
    			
    			return result;
    		}
    		catch (Exception exception)
    		{
    			//todo: log in db
    		}
    
    		return null;
    	}
    
    	public static byte[] UpdateCells(MemoryStream doc, string title, List<string> headers, List<List<string>> rows)
    	{
    		// Open the document for editing.
    		SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(doc, true);
    		WorksheetPart worksheetPart = GetWorksheetPartByName(spreadSheet, "Fax-ArchiveReport");
    
    		if (worksheetPart != null)
    		{
    
    			//----------------------------------------------- title
    		
    			Cell cellTitle = GetCell(worksheetPart.Worksheet, ColumnsNames[0], 2);
    			var inlineStringTitle = new InlineString();
    			
    			inlineStringTitle.AppendChild(new Text { Text = title ?? string.Empty });
    			cellTitle.AppendChild(inlineStringTitle);
    			cellTitle.DataType = new EnumValue<CellValues>(CellValues.InlineString);
    
    			//----------------------------------------------- data
    			
    			uint rowIndex = 4;
    			foreach (var row in rows)
    			{
    				uint rowCellIndex = 0;
    				foreach (var rowCell in row)
    				{
    					Cell cell = GetCell(worksheetPart.Worksheet, ColumnsNames[rowCellIndex], rowIndex);
    					var inlineStringRowCell = new InlineString();
    
    					inlineStringRowCell.AppendChild(new Text { Text = rowCell ?? string.Empty });
    					cell.AppendChild(inlineStringRowCell);
    					cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
    
    					rowCellIndex++;
    				}
    
    				rowIndex++;
    			}
    			
    			//-----------------------------------------------
    
    			worksheetPart.Worksheet.Save();
    			spreadSheet.Close();
    
    			var bytes = doc.ToArray();
    
    			doc.Dispose();
    
    			return bytes;
    		}
    
    		return null;
    	}
    
    	private static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
    	{
    		IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);
    
    		if (sheets.Count() == 0)
    		{
    			// The specified worksheet does not exist.
    
    			return null;
    		}
    
    		string relationshipId = sheets.First().Id.Value;
    		WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
    
    		return worksheetPart;
    	}
    
    	// Given a worksheet, a column name, and a row index, 
    	// gets the cell at the specified column and 
    	private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
    	{
    		Row row = GetRow(worksheet, rowIndex);
    
    		if (row == null)
    			return null;
    
    		return
    			row.Elements<Cell>()
    				.Where(c => string.Compare(c.CellReference.Value, columnName + rowIndex, true) == 0)
    				.First();
    	}
    
    	// Given a worksheet and a row index, return the row.
    	private static Row GetRow(Worksheet worksheet, uint rowIndex)
    	{
    		return worksheet.GetFirstChild<SheetData>().
    		  Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
    	}
    }
