	public class FileData
	{
		public int size { get; set; }
		public string data { get; set; }
		public string data2 { get; set; }
	}
	public class Files
	{
		public string FilePath { get; set; }
		public FileData FileData { get; set; }
	}
	public class RootObject
	{
		public Files files { get; set; }
	}
	
