	public class  MyDetailViewModel: MvxViewModel
	{
		private MyViewModel _myItem;
		
		public class Parameter
		{
			public DateTime Date {get; set; }
			public MyViewModel Item {get; set;}
		}
		public void Init(Parameter param)
		{
			_myItem = param.Item;
		}
	}
