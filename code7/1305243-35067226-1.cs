	using System.IO;
	namespace ConsoleApplication23
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				var nrValues=0;
				var fs = new FileStream(path, FileMode.Open, FileAccess.Read); //    open for reading
				// the file has opened; can read it now
				var sr = new StreamReader(fs);
				
				var textiles = new string[6, 4];
				while (!sr.EndOfStream)
				{
					var line = sr.ReadLine();
					var parts = line.Split(',');
					for (int i = 0; i < parts.Length; i++)
					{
						textiles[nrValues, i] = parts[i];
					}
					nrValues++;
				}
			}
		}
	}
