	public class TestViewModel : ViewModelBase
	{
		private int _TimeVal;
		public int TimeVal
		{
			get { return this._TimeVal; }
			set
			{
				this._TimeVal = value;
				RaisePropertyChanged(() => this.TimeVal);
				UpdateText();
			}
		}
		private string _TimeText;
		public string TimeText
		{
			get { return this._TimeText; }
			set { this._TimeText = value; RaisePropertyChanged(() => this.TimeText); }
		}
		public TestViewModel()
		{
			UpdateText(); // force initial value
		}
		private void UpdateText()
		{
			this.TimeText = TimeSpan.FromHours(this.TimeVal).ToString(@"hh\:mm\:ss");
		}
	}
