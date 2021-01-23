        public class UserControl1ViewModel : ViewModelBase
    {
	    public ICommand ResizeCommand
	    {
		    get
		    {
			    if (_resizeCommand == null) _resizeCommand = new RelayCommand(ResizeButton, () => true);
			    return _resizeCommand;
		    }
	    }
		public bool IsVisible
		{
			get { return _isVisible; }
			set
			{
				_isVisible = value;
				RaisePropertyChanged("IsVisible");
			}
		}
		public double Width
		{
			get { return _width; }
	        set
	        {
		        _width = value;
		        RaisePropertyChanged("Width");
	        }
		}
	    private RelayCommand _resizeCommand;
	    private bool _isVisible;
	    private double _width;
        public UserControl1ViewModel()
        {
	        Width = 100.0;
	        IsVisible = false;
        }
	    private void ResizeButton()
	    {
		    Width = Application.Current.MainWindow.ActualWidth * .65;
		    IsVisible = true;
	    }
    }
