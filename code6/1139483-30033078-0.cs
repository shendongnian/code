    static void Main(string[] args) {
    	ChromeOptions options = new ChromeOptions();
    	options.AddArgument("test-type");
    
    	// Initialize the Chrome Driver
    	using(var driver = new ChromeDriver(options)) {
    		driver.Navigate().GoToUrl("http://localhost/test.aspx");
    
    		// Get User Name field, Password field and Login Button
    		var userNameField = driver.FindElementById("txtUsername");
    		var userPasswordField = driver.FindElementById("txtPassword");
    		var loginButton = driver.FindElementById("btnLogin");
    
    		// Type user name and password
    		userNameField.SendKeys("MyUSN");
    		userPasswordField.SendKeys("MyPWD");
    
    		// and click the login button
    		loginButton.Click();
    
    		// Take a screenshot and save it into screen.png
    		driver.GetScreenshot().SaveAsFile(@"F:\temp\screen.png", ImageFormat.Png);
    
    		Console.ReadLine();
    	}
    }
