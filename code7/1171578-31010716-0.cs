    public class MainView
    {
	    public string LatestResult { get; set; }
    }
    public class ChildView
    {
	    private readonly MainView MainView;
	    public ChildView(MainView mainView)
	    {
		    this.MainView = mainView;
	    }
	    public void Calculation()
	    {
		    //Some calculation
    		this.MainView.LatestResult = "Some result";
	    }
    }
