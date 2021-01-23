    public class MyCanvas : Canvas
    {
    private readonly DispatcherTimer _dispatcherTimer;
    private Size _arrangeSize;
    private Size _drawnSize;
    
    public MyCanvas()
    {
    	_dispatcherTimer = new DispatcherTimer(DispatcherPriority.Render)
    		{
    			Interval = TimeSpan.FromMilliseconds(500)
    		};
    	_dispatcherTimer.Tick += (sender, args) =>
    		{
    			var dispatcherTimer = (DispatcherTimer)sender;
    			dispatcherTimer.Stop();
    			Debug.WriteLine("Draw call from DispatcherTimer");
    			Draw();
    		};
    }
    
    protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
    {
         _arrangeSize = arrangeSize;
    	if (_drawnSize != _arrangeSize)
    	{
    		QueueDrawCall();
    	}
    	return base.ArrangeOverride(arrangeSize);
    }
    
    private void QueueDrawCall()
        {
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
            }
    
            _dispatcherTimer.Start();
        }
    
    public void SetData(MyData data)
    {
        _data = data;
    	Console.WriteLine("Direct Draw Call " + data);
    	Draw();
    }
    
    private void Draw()
    {
        if (Children.Count > 0)
    	{
    		Children.Clear();
    	}
    
    	if (_data == null || _arrangeSize.IsEmpty)
    	{
    		return;
    	}
    
    	InternalDraw(); // Drawing logic goes in this function
    
    	_drawnSize = _arrangeSize;
    }
    }
