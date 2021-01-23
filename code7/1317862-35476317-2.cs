    public class SampleViewModel : ViewModelBase
	{
		public SampleViewModel()
	    {
	    }
		public ICommand OpenWindowCommand
		{
		    get { return new DelegateCommand(OpenSampleWindow); }
		}
		private void OpenSampleWindow()
		{
		    var sampleWindow = new SampleWindow();
		    sampleWindow.Show();
		}
	}
