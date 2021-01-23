			var relationLineNumbers = new List<int>();
			var dataLineNumbers = new List<int>();
			var relation = new StringBuilder();
			var data = new List<string>();
			using (var stream = new FileStream(filepath, FileMode.OpenOrCreate))
			{
				using (var sr = new StreamReader(stream))
				{
					string line;
					bool isRelation = false;
					bool isData = false;
					int lineNumber = 0;
					while ((line = sr.ReadLine()) != null)
					{
						lineNumber++;
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
								relation.Append(line);
								relationLineNumbers.Add(lineNumber);
							}
						}
						if (isData)
						{
							data.AddRange(line.Split(','));
							dataLineNumbers.Add(lineNumber);
						}
					}
				}
				Console.WriteLine("Relation");
				Console.WriteLine(relation.ToString());
				Console.WriteLine("Data");
				data.ForEach(Console.WriteLine);
