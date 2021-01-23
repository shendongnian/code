	IWebElement SlowRadionButton = driver.FindElement(By.ClassName("rtSlow"));
	IWebElement MediumRadionButton = driver.FindElement(By.ClassName("rtMedium"));
	IWebElement FastRadionButton = driver.FindElement(By.ClassName("rtFast"));
	var speedRadioButtons = new[] { SlowRadioButton. MediumRadioButton, FastRadionButton }
	foreach (IWebElement speedRadioButton in speedRadioButtons)
	{
		speedRadioButton.Click();
	}
