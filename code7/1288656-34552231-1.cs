		public Dictionary<string, List<TransformerStation>> ReadCSV(string fileName)
		{
			string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"), Encoding.UTF8);
			return lines.Select(line =>
			{
				string[] data = line.Split(';');
				return new TransformerStation(data[0], data[1], data[2]);
			})
			.GroupBy(ts => ts.Radial)
			.ToDictionary(g => g.Key, g => g.ToList());
		}
