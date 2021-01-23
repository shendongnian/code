			IEnumerable<FileInfo> parallelFiles = files.AsParallel();
			var result = new ConcurrentBag<string>();
			foreach (var file in parallelFiles)
			{
				foreach (string line in File.ReadLines(file.FullName))
				{
					if (line.Contains(keyWord))
					{
						result.Add(file.Name);
						break;
					}
					else if (line.Contains(stopWord))
					{
						break;
					}
				}
			}
