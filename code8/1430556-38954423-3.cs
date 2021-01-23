    public static IList<string> ReadFile(string fileName)
    {
        return (where !string.IsNullOrWhiteSpace(line)
				let columns = line.Split(',')
				where columns.Length >= 2 && 
					!string.IsNullOrWhiteSpace(columns[0]) &&
					!string.IsNullOrWhiteSpace(columns[1])
				select line).ToList();
    }
