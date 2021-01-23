    public class MainData : INotifyPropertyChanged 
    {
    	private string _emailAdress;
    	public string EmailAdress
    	{
    		get { return _emailAdress; }
    		set
    		{
    			_emailAdress = value;
    			OnPropertyChanged(nameof(EmailAdress));
    			OnPropertyChanged(nameof(EmailAdressValid));
    		}
    	}
    
    	private System.Windows.Media.Brush _emailAdressValid;
    	public System.Windows.Media.Brush EmailAdressValid
    	{
    		get 
    		{ 
    			if(_emailAdress.Contains("@"))
    			{
    			   _emailAdressValid = Brushes.Black;
    			}
    			else 
    			{
    				_emailAdressValid = Brushes.Red;
    			}
    			
    			return _emailAdressValid;
    		}
    	}
    }
