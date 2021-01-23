    public class OneItem
	{
		public string Name { get; set; }
		public double Height { get; set; }
		public double Weight { get; set; }
		public double Class { get; set; }
		public object data { get; set; }
		public object DataDisplay
		{
			get
			{
				if (data == null)
				{
					return string.Empty;
				}
				return data.ToString();
			}
		}
	}
