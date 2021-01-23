    public class MessageBoxViewModel : ViewModelBase
	{
		protected String windowTitle;
		public String WindowTitle {
        get { return windowTitle; }
        set { windowTitle = value; OnPropertyChanged("WindowTitle"); } }
    }
