	/// <summary>
	/// Convert a file to PDF using office _Document object
	/// </summary>
	/// <param name="InputFile">Full path and filename with extension of the file you want to convert from</param>
	/// <returns></returns>
	public void PrintFile(string InputFile)
	{
		// convert input filename to new pdf name
	    object OutputFileName = Path.Combine(
		    Path.GetDirectoryName(InputFile),
		    Path.GetFileNameWithoutExtension(InputFile)+".pdf"
	    );
		// Set an object so there is less typing for values not needed
		object missing = System.Reflection.Missing.Value;
		// `doc` is of type `_Document`
		doc.PrintOut(
			ref missing,	// Background
			ref missing,	// Append
			ref missing,	// Range
			OutputFileName,	// OutputFileName
			ref missing,	// From
			ref missing,	// To
			ref missing,	// Item
			ref missing,	// Copies
			ref missing,	// Pages
			ref missing,	// PageType
			ref missing,	// PrintToFile
			ref missing,	// Collate
			ref missing,	// ActivePrinterMacGX
			ref missing,	// ManualDuplexPrint
			ref missing,	// PrintZoomColumn
			ref missing,	// PrintZoomRow
			ref missing,	// PrintZoomPaperWidth
			ref missing,	// PrintZoomPaperHeight
		);
	}
