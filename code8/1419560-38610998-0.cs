    public static void ShowFiles(string dirpath)
	{
		Console.WriteLine(String.Format("Files in {0}:", dirpath));
		try
		{
			foreach (string f in Directory.GetFiles(dirpath))
			{
				Console.WriteLine('\t' + f);
			}
			foreach (string d in Directory.GetDirectories(dirpath))
			{
				ShowFiles(d);
			}
		}
		catch (Exception e)
		{
			// do something with e
		}
	}
