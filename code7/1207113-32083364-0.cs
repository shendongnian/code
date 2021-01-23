    public class Via
    {
    	public static By AdminMenu(string Id) // could also just use int
    	{
    		return By.CssSelector(string.Format("[selenium-admin-menu='{0}']", Id));
    	}
    	
    	public static By ImgSrc(string source)
    	{
    		return By.CssSelector(string.Format("img[src='{0}']", source));
    	}
    }
    //usage: 
    var menu3 = driver.FindElement(Via.AdminMenu("3"));
