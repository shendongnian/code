		public void ConvertDocToDocx(string path)
		{
			Application word = new Application();
			if (path.ToLower().EndsWith(".doc"))
			{
				var sourceFile = new FileInfo(path);
				var document = word.Documents.Open(sourceFile.FullName);
				string newFileName = sourceFile.FullName.Replace(".doc", ".docx");
				document.SaveAs2(newFileName,WdSaveFormat.wdFormatXMLDocument, 
								 CompatibilityMode: WdCompatibilityMode.wdWord2010);
				word.ActiveDocument.Close();
				word.Quit();
				File.Delete(path);
			}
		}
