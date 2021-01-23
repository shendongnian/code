	public class MyViewModel : ViewModelBase
	{
		private MyTabs _CurrentTab;
		public MyTabs CurrentTab
		{
			get { return this._CurrentTab;}
			set { this._CurrentTab = value; RaisePropertyChanged(() => this.CurrentTab); }
		}		
	}
