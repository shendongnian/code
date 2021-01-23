    foreach (string line in File.ReadLines(@"C:\\tumblrextract\\in7.txt"))
    {
        if (line.Contains("@"))
        {
            searchEmail.SendKeys(line);
            submitButton.Click();
            var result = driver.FindElement(By.ClassName("invite_someone_success")).Text;
            var ifThere = driver.FindElements(By.XPath("//*[@id='invite_someone']/div"));
            if (driver.FindElements(By.XPath("//*[@id='invite_someone']/div")).Count != 0)
            {
                driver.Url = "https://www.tumblr.com/lookup";
                Thread.Sleep(3000);
                driver.Url = "https://www.tumblr.com/following";
            }
            // If invite_someone_failure exists open this url
            else
            {
                using (StreamWriter writer = File.AppendText("C:\\tumblrextract\\out7.txt")) 
                {
                    writer.WriteLine(result + ":" + line);
                }
            }
        }
    }
