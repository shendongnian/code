		static void Main(string[] args)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "readEmbeddedResourceFile.Resources.MyFile.txt";
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (null != stream)
				{
					byte[] b1 = new byte[stream.Length]; // creat an array to hold the file
					stream.Read(b1, 0, (int)b1.Length); // read the file from the embedded resource
					File.WriteAllBytes("MyFile.txt", b1); // write the file to the current execution directory
				}
			}
		}
