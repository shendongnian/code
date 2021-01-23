    public void takeScreenShot()
    {
        string ssPath = System.IO.Path.Combine(_persistencePath, @"\Errors");
        string currTime = DateTime.Now.ToString(@"MMM-ddd-d-HH.mm");
        string fileName = System.IO.Path.Combine(ssPath, @"\ERROR-" + currTime + ".png");
        Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
        using (MemoryStream ms = new MemoryStream(ss.AsByteArray))
        using (Image screenShotImage = Image.FromStream(ms))
        {
            screenShotImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
