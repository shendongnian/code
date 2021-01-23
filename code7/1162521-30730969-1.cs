			StringBuilder sbRelation = new StringBuilder();
			List<string> lstData = new List<string>();
			using (var stream = new FileStream(filepath, FileMode.OpenOrCreate))
			{
				using (var sr = new StreamReader(stream))
				{
					String line;
					bool isRelation = false;
					bool isData = false;
					while ((line = sr.ReadLine()) != null)
					{
						if (line.StartsWith("@relation SMILEfeatures"))
						{
							isRelation = true;
							isData = false;
							continue;
						}
						if (line.StartsWith("@data"))
						{
							isData = true;
							isRelation = false;
							continue;
						}
						if (isRelation)
						{
							if (line.StartsWith("@attribute"))
							{
								sbRelation.Append(line);
							}
						}
						if (isData)
						{
							lstData.AddRange(line.Split(','));
						}
					}
				}
				Console.WriteLine("Relation");
				Console.WriteLine(sbRelation.ToString());
				Console.WriteLine("Data");
				lstData.ForEach(Console.WriteLine);
