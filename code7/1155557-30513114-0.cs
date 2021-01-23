    void Main()
    {
	    InputHandler(() => new InputSettings {
	        Name = "Test1",
		    Mask = "test mask"
	    });	
    }
    public static MvcHtmlString InputHandler(this HtmlHelper htmlHelper, 
        Func<InputSettings> method)
    {
        var parameters = method();        
        return new MvcHtmlString("");
    }
