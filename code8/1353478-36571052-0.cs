    public class TextFileStreamReader
	{
		private string _FullFileName;
		public TextFileStreamReader(string fullfilename)
		{
			_FullFileName = fullfilename;
		}
		public StreamReader GetStream()
		{
			try
			{
				StreamReader reader = new StreamReader(_FullFileName);
				Console.WriteLine("File {0} successfully opened.", _FullFileName);
				return reader;  //Can't do this - but how do I return a StreamReader?
			}
			catch (FileNotFoundException)
			{
				Console.Error.WriteLine(
				"Can not find file {0}.", _FullFileName);
			}
			catch (DirectoryNotFoundException)
			{
				Console.Error.WriteLine(
				"Invalid directory in the file path.");
			}
			catch (IOException)
			{
				Console.Error.WriteLine(
				"Can not open the file {0}", _FullFileName);
			}
			return null;
		}
	}
