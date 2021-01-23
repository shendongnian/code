    public static void Main(string[] args)
    {
    	string input = args[0];
    	List<string> files = input.Split('.').ToList<string>();
    	for (int i = 0; i < files.Count - 1; i++)
    	{
    		files[i] = files[i].Replace("txt","");
    		files[i] += ".txt";
    	}
    	for (int i = 0; i < files.Count - 1; i++)
    	{
    		Console.WriteLine(files[i]);
    	}
    	return;
    }
