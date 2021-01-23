    public class ImageProcessingModel : INotifyPropertyChanged
    {
    	public BitmapSource MainFrameBitmap
    	{
    	    get
    	    {
    	        return _mainFrameBitmap;
    	    }
    	    private set
    	    {
    	        _mainFrameBitmap = value;
    	        OnPropertyChanged("MainFrameBitmap");
    	    }
    	}
    	
    	public ImageProcessingModel(int updatePeriodInMilliseconds)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += ServiceUiDispatcherTimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, updatePeriodInMilliseconds);
        }
    	
    
        private void ServiceUiDispatcherTimerTick(object sender, EventArgs e)
        {
            try
            {
                MainFrameBitmap = ReadBitmap(FrameWidth, FrameHeight, Stride);
    		}
            catch (Exception ex)
            {
                Console.WriteLine(@"UI Runtime Exception:" + ex.Message);
            }
        }
        
    }
