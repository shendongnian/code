     var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("you URL");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //check if there is any iframe then get that frame and switch on frame using folloiwng code.
            //var frame = wait.Until(ExpectedConditions.ElementExists(By.Id("frame_id"));
            //driver.SwitchTo().Frame(frame);
            //get video tag.
            var vTag = wait.Until(ExpectedConditions.ElementExists(By.TagName("video")));
            var videoSrc = vTag.GetAttribute("src");
