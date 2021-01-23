	namespace ConsoleApplication1
	{
		using System;
		using System.Globalization;
		using System.IO;
		class Program
		{
			static void Main(string[] args)
			{
				RenameJpegFiles(@"c:\tmp");
			}
			private static void RenameJpegFiles(string path)
			{
				foreach (var filename in Directory.GetFiles(path))
				{
					string suffix = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString(CultureInfo.InvariantCulture);
					var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
					var newFilename = string.Format("{0}{1}.jpg", fileNameWithoutExtension, suffix);
					var newFullFilename = Path.Combine(path, newFilename);
					File.Move(filename, newFullFilename);
					Console.WriteLine("Renaming: {0} -> {1}", filename, newFullFilename);
				}
			}
		}
	}
----------
	Renaming: c:\tmp\somepic.jpg -> c:\tmp\somepic63569994418865.jpg
	Renaming: c:\tmp\some_other_pic -> c:\tmp\some_other_pic63569994418865.jpg
	Press any key to continue . . .
