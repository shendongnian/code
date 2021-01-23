	void Main()
	{
		string path = @"temp\A\B";
		var parts = path.Split(new [] { Path.DirectorySeparatorChar });
		var rootPath = "c:\\";
		
		foreach(var result in DirectoryEx.EnumerateDirectories(rootPath, parts.First()))
		{
			var checkPath = Path.Combine(result, String.Join(""+Path.DirectorySeparatorChar, parts.Skip(1).ToArray()));
			if (Directory.Exists(checkPath))
				Console.WriteLine("Found : " + checkPath);
		}
	}
	
	public class DirectoryEx
	{
		public static IEnumerable<string> EnumerateDirectories(string dir, string name)
		{
			IEnumerable<string>  dirs;
		
            // yield return may not be used in try with catch.
			try { dirs = Directory.GetDirectories(dir); } 
			catch(UnauthorizedAccessException) { yield break; }
			
			foreach (var subdir in dirs)
			{
				if(Path.GetFileName(subdir).Equals(name, StringComparison.OrdinalIgnoreCase))
					yield return subdir;
			
				foreach(var heir in EnumerateDirectories(subdir, name))
					yield return heir;
			}
		}
	}
