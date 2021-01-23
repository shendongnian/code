    class MainClass
    {
        
        public static void Main(string[] args)
        {
            string userName = "username";
            string password ="password";
            string steamProfile = "steamprofile";
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            using (var driver = new FirefoxDriver())
            {
                
                // Go to the home page
                driver.Navigate().GoToUrl("https://store.steampowered.com//login/?redir=0");
                // Get the page elements
                var userNameField = driver.FindElementById("input_username");
                var userPasswordField = driver.FindElementById("input_password");
                //var loginButton = driver.FindElementById("login_btn_signin");
                var loginButton = driver.FindElementByXPath("//button[@class='btnv6_blue_hoverfade  btn_medium']");
                 
                // Type user name and password
                userNameField.SendKeys(userName);
                userPasswordField.SendKeys(password);
                // and click the login button
                loginButton.Click();
                System.Threading.Thread.Sleep(5000);
                //Type authorization code and enter manually.
                System.Console.ReadKey();
                driver.Navigate().GoToUrl("http://steamcommunity.com/profiles/"+steamProfile+"/badges");
                driver.GetScreenshot().SaveAsFile(@"screen.png", ImageFormat.Png); //Debuggin purposes, as I was first using PhantomJS
                htmlDoc.LoadHtml(driver.PageSource);
                Console.Clear();
            }
            HtmlNodeCollection col = htmlDoc.DocumentNode.SelectNodes("//span[@class='progress_info_bold']");
            foreach (HtmlNode n in col)
            {
                Console.WriteLine(n.InnerText);
            }
        }
    }
