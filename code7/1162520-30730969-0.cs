			StringBuilder sbRelation = new StringBuilder();
			StringBuilder sbData = new StringBuilder();
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
								// you can trim the @attribute prefix before append, if you don't need it 
							}
						}
						if (isData)
						{
							sbData.Append(line);
								// you can split the string using , delimiter to get only the numbers
 						}
					}
				}
				Console.WriteLine("Relation");
				Console.WriteLine(sbRelation.ToString());
				Console.WriteLine("Data");
				Console.WriteLine(sbData.ToString());
			}
