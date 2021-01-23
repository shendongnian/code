    namespace Example.Client.ExampleService
	{
		public partial class Search // the rest of the definition is in Reference.cs
		{
			private bool _isSelected;
			public bool IsSelected
			{
				get { return _isSelected; }
				set
				{
					_isSelected = value;
					RaisePropertyChanged("IsSelected");
				}
			}
		}
	}
