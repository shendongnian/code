	public class DataPlaneMatrix : List<List<string>>
	{
		public List<string> GetColumn(int value)
		{
			return this.Select(line => line[value]).ToList();
		}
	}
