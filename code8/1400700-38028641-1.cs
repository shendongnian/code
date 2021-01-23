	public class Alternative
	{
		public double confidence { get; set; }
		public string transcript { get; set; }
	}
	public class Result
	{
		public List<Alternative> alternatives { get; set; }
		public bool final { get; set; }
	}
	public class RootObject
	{
		public List<Result> results { get; set; }
		public int result_index { get; set; }
	}
