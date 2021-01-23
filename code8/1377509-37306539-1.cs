    public class ViewModel : BaseViewModel
    {
    	private ICommand rotateCommand;
    	private double rotateAngle;
    
    	public ICommand RotateCommand
    	{
    		get
    		{
    			if(rotateCommand == null)
    			{
    				rotateCommand = new RelayCommand(() => {
    					RotateAngle += 90;
    				});
    			}
    
    			return rotateCommand;
    		}
    	}
    
    	public double RotateAngle
    	{
    		get
    		{
    			return rotateAngle;
    		}
    
    		private set
    		{
    			if(value != rotateAngle)
    			{
    				rotateAngle = value;
    				OnPropertyChanged("RotateAngle");
    			}
    		}
    	}
    }
