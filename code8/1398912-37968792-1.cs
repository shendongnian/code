	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			SearchBox.Paste += SearchBox_Paste; // Subscribe to the Paste event
		}
		private void SearchBox_Paste(object sender, TextControlPasteEventArgs e)
		{
            // The code in here will be fired when the SearchBox.Paste event is raised
			// Do something in here, when text is pasted to the SearchBox.
			// You can use the e parameter to see more data about the event
		}
	}
