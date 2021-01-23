	public enum MyEnum
	{
		One,
		Two,
		Three
	}
	public class MyViewModel : ViewModelBase
	{
		private MyEnum _CurrentValue = MyEnum.One;
		public MyEnum CurrentValue
		{
			get { return this._CurrentValue; }
			set { this._CurrentValue = value; RaisePropertyChanged(); }
		}
		public ICommand CheckedCommand { get { return new RelayCommand<MyEnum>(value => this.CurrentValue = value); } }
	}
