		void mainMethod() 
		{
			Stream theFile = Assembly.GetExecutingAssembly().GetManifestResourcesStream("pathToFile");
			using (StreamReader fileUsage = new StreamReader(theFile))
			{
				Method1(fileUsage);
				Method2(fileUsage);
			}
        }
    	private static void Method1(StreamReader fileUsage)
		{
			if (fileUsage != null && fileUsage.BaseStream.CanSeek && fileUsage.BaseStream.CanRead)
			{
				fileUsage.BaseStream.Seek(0, SeekOrigin.Begin);
				Console.WriteLine(fileUsage.ReadLine());
			}
		}
