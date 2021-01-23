    [TestMethod]
        public void StackOverflow()
            {
            BrowserWindow browser = BrowserWindow.Launch(new Uri("https://onboard.passageways.com/"));
            var _hyper = new HtmlButton(browser);
            _hyper.SearchProperties.Add("ID", "PassagewaysLogin");
            _hyper.WaitForControlReady();
            Mouse.Click(_hyper);
            var _email = new HtmlEdit(browser);
            _email.SearchProperties.Add("ID", "Email");
            _email.WaitForControlReady();
            Keyboard.SendKeys(_email, "testemail@email.com");
            Playback.Wait(10000);
            }
    
     
