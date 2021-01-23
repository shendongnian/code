        protected bool FindTextInWord(object text, string flname)
		{
			object matchCase = false;
			object matchWholeWord = true;
			object matchWildCards = false;
			object matchSoundsLike = false;
			object matchAllWordForms = false;
			object forward = true;
			object format = false;
			object matchKashida = false;
			object matchDiacritics = false;
			object matchAlefHamza = false;
			object matchControl = false;
			object read_only = false;
			object visible = true;
			object replace = 2;
			object wrap = 1;
			Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
			Microsoft.Office.Interop.Word.Document docOpen = app.Documents.Open(flname);
			bool val = false;
			try
			{
				val = app.Selection.Find.Execute(ref text, ref matchCase, ref matchWholeWord,
				ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap,
				ref format, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			}
			finally
			{
				app.Documents.Close();
			}
			return val;
		}
