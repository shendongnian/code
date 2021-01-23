    if (closeButton.Location.Y < 0 || closeButton.Location.X < 0)
    {
        IJavaScriptExecutor jse = Session.Driver as IJavaScriptExecutor;
        jse.ExecuteScript("arguments[0].click()", closeButton);
        // Log.Error("Could not close button. The popup displayed the close_button off-screen giving it a negative x or y pixel location.");
    }
    else
    {
        closeButton.Click();
    }
