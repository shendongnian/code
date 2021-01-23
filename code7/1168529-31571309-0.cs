            driver = AppiumDriver<AppiumWebElement>(server.ServerUri, capabilities);
            public static void Swipe(IPerformsTouchActions driver, int startX, int startY, int endX, int endY, int duration) 
            {
                ITouchAction touchAction = new TouchAction(driver) 
                .Press (startX, startY)
                .Wait (duration)
                .MoveTo (endX, endY)
                .Release ();
                
                touchAction.Perform();
		    }
