	public static Func<IWebDriver, bool> WaitUntilFrameLoadedAndSwitchToIt(By byToFindFrame)
	{
		return (driver) =>
				{
					try
					{
						return driver.SwitchTo().Frame(driver.FindElement(byToFindFrame));
					}
					catch (Exception)
					{
						return null;
					}
					
					return true;
				};
	}
