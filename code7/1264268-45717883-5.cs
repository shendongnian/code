	public static void ValidateWordDocument(string fileName)
	{
		using (var docx = WordprocessingDocument.Open(fileName, true))
		{
			ValidateOpenXmlDocument(docx);
		}
	}
