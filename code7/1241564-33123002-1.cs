    public int[,] CreateMatrix(string s)
    {
	    List<string> cleanedRows = Regex.Split(s, @"}\s*,\s*{")
							            .Select(r => r.Replace("{", "").Replace("}", "").Trim())
							            .ToList();
	
	    int[] columnsSize = cleanedRows.Select(x => x.Split(',').Length)
								       .Distinct()
								       .ToArray();
	
	    if (columnsSize.Length != 1)
		    throw new Exception("All columns must have the same size");
	
	    int[,] matrix = new int[cleanedRows.Count, columnsSize[0]];
	    string[] data;
	
	    for (int i = 0; i < cleanedRows.Count; i++)
	    {
		    data = cleanedRows[i].Split(',');
		    for (int j = 0; j < columnsSize[0]; j++)
		    {
			    matrix[i, j] = int.Parse(data[j].Trim());
		    }
	    }
	
	    return matrix;
    }
