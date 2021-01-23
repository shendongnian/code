	public List<Cell> GetNeighbors(int x, int y)
	{
		var neighbors = new List<Cell>();
		neighbors.Add(GetCell(x - 1, y - 1));
		neighbors.Add(GetCell(x + 0, y - 1));
		neighbors.Add(GetCell(x + 1, y - 1));
		// ...
		neighbors.Add(GetCell(x + 1, y + 1));
		
		return neighbors;
	}
