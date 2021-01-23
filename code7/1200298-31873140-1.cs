    class Program
	{
		static void Main(string[] args)
		{
			var installedLocation = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
			var di = installedLocation.CreateSubdirectory("MyFolder");
			File.WriteAllText(Path.Combine(di.FullName, "File.txt"), "This will be written to the file");
			var installedPath = AppDomain.CurrentDomain.BaseDirectory;
			var di2 = Directory.CreateDirectory(Path.Combine(installedPath, "MyFolder2"));
			File.WriteAllText(Path.Combine(di.FullName, "File2.txt"), "This will be written to the file");
		}
	}
