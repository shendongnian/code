			string data = @"S.No  Name   Address  Company
    ----  ----   -------  -------
     1     xxx    yyy     zzz
     2     vvv    nnn     dsd";
			var lines = data.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
			var lengths = lines[1] + " "; //We'll think the dashes are the column markers.
			
			var insideColumn = false;
			int start = 0;
			var columns = new List<Tuple<int, int>>();
			for (int i = 0; i < lengths.Length; i++) {
				if (insideColumn && lengths[i] == ' ') {
					insideColumn = false;
					columns.Add(Tuple.Create(start, i));
				}
				if (!insideColumn && lengths[i] == '-') {
					insideColumn = true;
					start = i;
				}
			}
			
			var headers = new List<string>(columns.Count);
			for (int i = 0; i < columns.Count; i++) {
				headers.Add(lines[0].Substring(columns[i].Item1, columns[i].Item2 - columns[i].Item1).Trim());
			}
			
			var table = new List<Dictionary<string,string>>();
			for (int i = 2; i < lines.Length; i++) {
				var record = new Dictionary<string, string>();
				var line = lines[i].PadRight(lengths.Length);
				for (int j = 0; j < columns.Count; j++) {
					record[headers[j]] = line.Substring(columns[j].Item1, columns[j].Item2 - columns[j].Item1).Trim();
				}
				table.Add(record);
			}
