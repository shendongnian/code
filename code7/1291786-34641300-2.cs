    [TestMethod]
        public void StackOverflow()
            {
            BrowserWindow browser = BrowserWindow.Launch(new Uri("https://onboard.passageways.com/"));
            
            var _hyper = new HtmlButton(browser);
            _hyper.SearchProperties.Add("ID", "PassagewaysLogin");
            _hyper.WaitForControlReady();
            LoadingOverlay(browser);
            Mouse.Click(_hyper);
            
            var _email = new HtmlEdit(browser);
            
            _email.SearchProperties.Add("ID", "Email");
            _email.WaitForControlReady();
            LoadingOverlay(browser);
            Keyboard.SendKeys(_email, "testemail@email.com");
            Playback.Wait(10000);
            }
            
            public static void LoadingOverlay(BrowserWindow browser)
            {
            var _image = new HtmlDiv(browser);
            _image.SearchProperties.Add("ID", "loadingOverlay");
                _image.WaitForControlReady();
            }
    
     
