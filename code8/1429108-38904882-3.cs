        public static Screenshot GetScreenshot(ChromeDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            return ss;
        }
        public static void SaveScreenshot(byte[] byteArray, string location)
        {
            var stream = new MemoryStream(byteArray);
            var img = Image.FromStream(stream);
            img.Save(location);
            stream.Dispose();
        }
