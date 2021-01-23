	public void Draw()
	{
		string[] lines = map.Replace("\r", "").Split('\n');
		for(int y = 0; y < lines.Length; y++)
		{
			string curr = lines[y];
			if (y == playerY)
				curr = curr.Substring(0, playerX) + "@" + curr.Substring(playerX + 1);
			Console.WriteLine(curr);
		}
	}
