     public DriverExecutor CaptureScreen(string filename)
        {
            Screenshot shot = this.myRemoteWebDriver.GetScreenshot();
            MemoryStream ms;
            Image imgShot;
            Bitmap bitmap;
            try 
            {
                using (ms = new MemoryStream(shot.AsByteArray))
                using (imgShot = Image.FromStream(ms))
                using (bitmap = new Bitmap(imgShot))
                {
                    bitmap.Save(filename, ImageFormat.Bmp);
                }
            }catch(Exception err){}
            return this;
        } 
