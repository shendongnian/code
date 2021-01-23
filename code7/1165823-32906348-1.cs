	public class OpenFileCommand : ICommand
	{
		private OpenFileDialog openFile = new OpenFileDialog();
		public bool CanExecute(object parameter)
		{
			return true;
		}
		public void Execute(object parameter)
		{
			var rtf = parameter as RichTextBox;
			rtf.Document = LoadScript();
		}
		public event EventHandler CanExecuteChanged;
		private FlowDocument LoadScript()
		{
			openFile.InitialDirectory = "C:\\";
			if (openFile.ShowDialog() == true)
			{
				string originalfilename = System.IO.Path.GetFullPath(openFile.FileName);
				if (openFile.CheckFileExists)
				{
					var script = new FlowDocument();
					TextRange range = new TextRange(script.ContentStart, script.ContentEnd);
					FileStream fStream = new FileStream(originalfilename, System.IO.FileMode.OpenOrCreate);
					range.Load(fStream, DataFormats.Rtf);
					fStream.Close();
					return script;
				}
			}
			return null;
		}
	}
