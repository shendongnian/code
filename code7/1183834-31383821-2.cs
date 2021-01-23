    public class ViewModel : INotifyPropertyChanged
    {
    	public ICommand ChangeColorCommand { get; set; }
    
    	protected Brush _color;
    	public Brush LabelColor
    	{
    		get { return _color; }
    		set
    		{
    			_color = value;
    			OnPropertyChange();
    		}
    	}
    
    	public ViewModel()
    	{
    		LabelColor = Brushes.Yellow;
    		ChangeColorCommand = new RelayCommand((o) =>
    		{
    			LabelColor = new BrushConverter().ConvertFromString(o.ToString()) as SolidColorBrush;
    		});
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChange([CallerMemberName] string propertyName = null)
    	{
    		var handler = PropertyChanged;
    		if (handler != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
