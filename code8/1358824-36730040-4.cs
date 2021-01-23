	public class  MyDetailViewModel: MvxViewModel
	{
		private MyViewModel _myItem;
		
		public class Parameter
		{
			public DateTime Date {get; set; }
			public string Name {get; set;}
		}
		public void Init(Parameter param)
		{
			Name = param.Name;
		}
	}
