	using System.IO;
	namespace ConsoleApplication23
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				int nrValues=0;
				FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //    open for reading
				// the file has opened; can read it now
				StreamReader sr = new StreamReader(fs);
				
				string[,] textiles = new string[6, 4];
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					string[] parts = line.Split(',');
					for (int i = 0; i < parts.Length; i++)
					{
						textiles[nrValues, i] = parts[i];
					}
					nrValues++;
				}
			}
		}
	}
