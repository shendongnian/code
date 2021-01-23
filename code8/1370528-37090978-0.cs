    public class MyViewModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	private DateTime _now;
    	
    	public MyViewModel()
    	{
    		_now = DateTime.Now;
    		DispatcherTimer timer = new DispatcherTimer();
    		timer.Interval = TimeSpan.FromMilliseconds(500);
    		timer.Tick += new EventHandler(timer_Tick);
    		timer.Start();
    	}
    
    	public DateTime CurrentDateTime
    	{
    		get {return _now;}
    		private set
    		{
    			_now = value;
    			PropertyChanged(this, new PropertyChangedEventArgs("CurrentDateTime"));
    		}
    	}
    	void timer_Tick(object sender, EventArgs e)
    	{
    		CurrentDateTime = DateTime.Now;
    	}
    
    }
    <Label x:Name="SomeLabel" Content="{Binding CurrentDateTime}" ContentStringFormat="yyyy-MM-dd HH:mm:ss" />
