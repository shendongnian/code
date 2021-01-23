	public partial class ThisAddIn
	{
		WordSaveHandler wsh = null;
		private void ThisAddIn_Startup(object sender,
										System.EventArgs e)
		{
			// attach the save handler
			wsh = new WordSaveHandler(Application);
			wsh.AfterAutoSaveEvent += new WordSaveHandler.AfterSaveDelegate(wsh_AfterAutoSaveEvent);
			wsh.AfterSaveEvent += new WordSaveHandler.AfterSaveDelegate(wsh_AfterSaveEvent);
			wsh.AfterUiSaveEvent += new WordSaveHandler.AfterSaveDelegate(wsh_AfterUiSaveEvent);
		}
		void wsh_AfterUiSaveEvent(Word.Document doc, bool isClosed)
		{
			if (!isClosed)
				MessageBox.Show("After SaveAs Event");
			else
				MessageBox.Show("After Close and SaveAs Event. The filname was: " + wsh.ClosedFilename);
		}
		void wsh_AfterSaveEvent(Word.Document doc, bool isClosed)
		{
			if (!isClosed)
				MessageBox.Show("After Save Event");
			else
				MessageBox.Show("After Close and Save Event. The filname was: " + wsh.ClosedFilename);
		}
		void wsh_AfterAutoSaveEvent(Word.Document doc, bool isClosed)
		{
			MessageBox.Show("After AutoSave Event");
		}
		
		// etc.
		
	}
