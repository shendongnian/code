	private void PerformSequence(int idx)
	{
		var stringChars = new char[26];
		var random = new Random();
		var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		var filePath = Path.Combine(@"C:\Top Folder\File Folder",
									string.Format("file{0}.dat",idx))
		for (int i = 0; i < stringChars.Length; i++) {
			stringChars[i] = chars[random.Next(chars.Length)];
		}
		string string1 = new string(stringChars);
		File.WriteAllText(filePath,
			string1);
		using(StreamReader sr = 
			File.OpenText(filePath) 
		{
			string s = "";
			while ((s = sr.ReadLine()) != null) {
				Console.WriteLine(s);
				Console.WriteLine("file{0}.dat is a clean file", idx);
				Console.WriteLine("Path to file{0}.dat - {1}", idx, path1);
			}
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
    //Example call (for sequence one) = PerformSequence(1);
