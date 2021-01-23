	private void WriteFile(int idx, string inputString ,string threatLevel)
	{
		File.WriteAllText(@"C:\Top Folder\File Folder\file2.dat", inputString);
		string filePath = Path.Combine(@"C:\Top Folder\FIle Folder", 
                                         string.Format("file{0}.dat", idx));
		using(StreamReader sr = File.OpenText(filePath))
		{
			string s = "";
			while ((s = sr.ReadLine()) != null) {
				Console.WriteLine(s);
				Console.WriteLine("file{0}.dat is a {1} file", idx, threatLevel);
				Console.WriteLine("Path to file{0}.dat - {1}\n", idx, filePath);
			}
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
	//WriteToFile(1, string1, "clean");
	//WriteToFile(2, string2, "HIGH THREAT virus");
	//WriteToFile(3, string2, "MODERATE THREAT virus");
