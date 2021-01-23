	public class DataPlaneMatrix : List<List<string>>
	{
		public List<string> GetColumn(int value)
		{
			List<string> columnValue = new List<string>();
			foreach (List<string> line in this)
			{
				columnValue.Add(line[value]);
			}
			return columnValue;
		}
	}
