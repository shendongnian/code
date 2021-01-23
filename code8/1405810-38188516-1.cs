    public partial class MessageBoxView : Window
	{
        private MessageBoxView()
		{
			InitializeComponent();
			MessageBoxViewModel dvm = new MessageBoxViewModel();
			dvm.PropertyChanged += (s, e) => this.PropertyChanged(s,e);
			DataContext = dvm;
		}
		private void PropertyChanged(object e, PropertyChangedEventArgs s)
		{
			if (s.PropertyName == "WindowTitle")
			{
				titleBar.Content = (DataContext as MessageBoxViewModel).WindowTitle;
			}
		}
    }
