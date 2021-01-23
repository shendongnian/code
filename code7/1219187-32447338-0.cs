	public class TestViewModel
	{
		public IList<object> Items { get; set; }
		public TestViewModel()
		{
			this.Items = new List<object>();
			for (int i = 0; i <= 12; i++)
			{
				var size = 5.0 * Math.Pow(1.4, Math.Abs(i-6));
				this.Items.Add(new { X = 50 + i * 25 - size / 2, Y = 50 + i * 25 - size / 2, Radius = size });
			}
		}
	}
