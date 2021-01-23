	public static async Task<T> Run<T>(Func<T> func)
	{
		var mapName = Guid.NewGuid().ToString();
		using (var mapFile = MemoryMappedFile.CreateNew(mapName, 65536))
		{
			using (var stream = mapFile.CreateViewStream())
			using (var bw = new BinaryWriter(stream))
			{
				bw.Write(func.Method.DeclaringType.AssemblyQualifiedName);
				bw.Write(func.Method.Name);
				if (func.Target == null)
				{
					bw.Write(0);
				}
				else
				{
					using (var ms = new MemoryStream())
					{
						new BinaryFormatter().Serialize(ms, func.Target);
						var data = ms.ToArray();
						bw.Write(data.Length);
						bw.Write(data);
					}
				}
			}
			using (var process = Process.Start(new ProcessStartInfo("LambdaRunner", mapName) { UseShellExecute = false, CreateNoWindow = true }))
			{
				process.EnableRaisingEvents = true;
				await process.WaitForExitAsync();
				switch (process.ExitCode)
				{
					case -10: throw new Exception("Type not accessible.");
					case -11: throw new Exception("Method not accessible.");
					case -12: throw new Exception("Unexpected argument count.");
					case -13: throw new Exception("Target missing.");
					case 0: break;
				}
			}
			using (var stream = mapFile.CreateViewStream())
			{
				return (T)(object)new BinaryFormatter().Deserialize(stream);
			}
		}
	}
