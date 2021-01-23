			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestProject.MyAssembly.dll"))
			{
				if (stream == null)
				{
					throw new InvalidOperationException("Cannot find resource.");
				}
				using (var reader = new BinaryReader(stream))
				{
					var rawAssembly = new byte[(int)stream.Length];
					reader.Read(rawAssembly, 0, (int)stream.Length);
					var assembly = Assembly.Load(rawAssembly);
					// Do what you want with the assembly
				}
			}
