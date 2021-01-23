     class Result
        {
            static int i = 1 ;
            public static void screenshot() 
            {
    
                ITakesScreenshot screenshotDriver = PropertiesCollection.driver as ITakesScreenshot;
                Screenshot screenCapture = screenshotDriver.GetScreenshot();
                string path = @"..\..\Results\";
    
                string timestamp = DateTime.Now.ToString("yy-MM-dd hh-mm-ss");
                screenCapture.SaveAsFile(@path + i + ". " + timestamp + ".png", System.Drawing.Imaging.ImageFormat.Png);
                i++;
    
            }
        }
