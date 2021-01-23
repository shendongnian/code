    public class TabsPage : TabbedPage
    {
    	public TabsPage ()
    	{
    		this.Children.Add (new Page1 () { Title = "Home" });
    		this.Children.Add (new Page2 () { Title = "Browse" });
    		this.Children.Add (new Page3 () { Title = "Test" });
    	}
    }
