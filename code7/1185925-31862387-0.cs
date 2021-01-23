    public class MainView : BaseView
    {
    	private CaptureElement _captureElement;
    	public CaptureElement CaptureElement
    	{
    		get
    		{
    			return _captureElement;
    		}
    	}
    
    	public MainView()
    	{
    		InitializeCamera();
    	}
    
    	private async void InitializeCamera()
    	{
    		// media capture creation
    	
    		_captureElement = new CaptureElement();
    		_captureElement.Source = mediaCapture;
    		await _cameraService.StartPreviewAsync();
    	}
    }
