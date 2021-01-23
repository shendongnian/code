	internal static class AppSettings
	{
		static AppSettings()
		{
			Console.WriteLine("In constructor");
			FileEncodingText = "UTF8";
		}
	
		private static string _fileEncodingText = "UTF8";
		public static string FileEncodingText
		{
			get { return _fileEncodingText; }
			set
			{
				Console.WriteLine("Setting value: " + value);
				string oldValue = _fileEncodingText;
				_fileEncodingText = value;
	
				try
				{
					FileEncoding = Encoding.GetEncoding(value);
				}
				catch (System.Exception)
				{
					 Console.WriteLine("Exception");
					_fileEncodingText = oldValue;
					FileEncoding = Encoding.UTF8;
				}
			}
		}
	
		public static Encoding FileEncoding { get; private set; }
	}
	
	
	public class Program
	{
		public static void Main()
		{
			AppSettings.FileEncodingText = "UTF16";
			Console.WriteLine(AppSettings.FileEncodingText);
		}
	}
