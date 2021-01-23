	public class MyViewModel : ViewModelBase
	{
		public Record[] Records {get; set;}
		public MyViewModel()
		{
			this.Records = new Record[] {
				new Record{Field = false},
				new Record{Field = true},
			};
		}
	}
	public class Record
	{
		public bool Field { get; set; }
	}
