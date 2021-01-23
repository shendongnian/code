    public class ScanPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
    	//...    	
    	private void GetOcrFromService()
    	{
    		//...
    		TextProcessing value = OcrService.Get();
    		OcrTextVM = value;	
    	}
    }
