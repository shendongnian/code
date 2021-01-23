    public void SaveScreenShot(string screenshotFirstName)
	{
		var folderLocation = ConfigurationManager.AppSettings["LogPath"] +"\\ScreenShot\\";
		if (!Directory.Exists(folderLocation))
			Directory.CreateDirectory(folderLocation);
		var screenshot = ((ITakesScreenshot) _driver).GetScreenshot();
		var image = ScreenshotToImage(screenshot);
		var filename = new StringBuilder(folderLocation);
		filename.Append(screenshotFirstName);
		filename.Append(".png");
		image.Save(filename.ToString(), ImageFormat.Png);
	}
    private static Image ScreenshotToImage(Screenshot screenshot)
	{
		Image screenshotImage;
		using (var memStream = new MemoryStream(screenshot.AsByteArray))
		{
			screenshotImage = Image.FromStream(memStream);
		}
		return screenshotImage;
	}
	[TearDown]
	public static void Cleanup()
	{
		Browser.Dispose();
		var dateTimeNow = DateTime.Now;
		var data = dateTimeNow.ToString("dd/MM/yyyy HH:mm:ss");
		IntegrationTest.WriteInLog("Test ends at: " + data);
		IntegrationTest.WriteInLog("Time to execute: " + (dateTimeNow - InicioTeste).TotalSeconds + " seconds");
		var takeScreenShoot = false;
		if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure))
		{
			IntegrationTest.WriteInLog("FAILS");
			takeScreenShoot = true;
		}
		else if(TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Error))
		{
			IntegrationTest.WriteInLog("ERROR");
			takeScreenShoot = true;
		}
		else if(TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpError))
		{
			IntegrationTest.WriteInLog("SETUP ERROR");
			takeScreenShoot = true;
		}
		else if(TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpFailure))
		{
			IntegrationTest.WriteInLog("SETUP FAILURE");
			takeScreenShoot = true;
		}
		else if(TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive))
		{
			IntegrationTest.WriteInLog("INCONCLUSIVE");
		}
		else if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success))
		{
			IntegrationTest.WriteInLog("SUCESS");
		}
		else
		{
			IntegrationTest.WriteInLog("UNKNOW");
		}
		if (takeScreenShoot)
		{
            Browser.SaveScreenShot(TestContext.CurrentContext.Test.Name.ToUpper()));
			IntegrationTest.WriteInLog("Screenshot saved as " + TestContext.CurrentContext.Test.Name.ToUpper()));
		}
		IntegrationTest.WriteInLog("\n");
	}
