    public class MainViewModel
    {
	    public ObservableCollection<OptionStrike> oOs { get; set; }
	
	    public MainViewModel()
	    {
		    oOs = new ObservableCollection<OptionStrike>(new OptionStrike[]
			{
				new OptionStrike("Put", 7500.00, 12345),
				new OptionStrike("Call", 7500.00, 123),
				new OptionStrike("Put", 8000.00, 23645),
				new OptionStrike("Call", 8000.00,99999)
			});
	    }
    }
