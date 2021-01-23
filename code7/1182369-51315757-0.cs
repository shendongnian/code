            public void launch88()
            {
                BrowserWindow Browser = new BrowserWindow();
                string url = "http://abcd:8080/xyz/";
                BrowserWindow.Launch();
                Browser.NavigateToUrl(new Uri(url));
    
                WinWindow securityWindow = new WinWindow();
                securityWindow.SearchProperties.Add(WinWindow.PropertyNames.Name, "Windows Security",PropertyExpressionOperator.EqualTo);
                securityWindow.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "Credential Dialog Xaml Host", PropertyExpressionOperator.EqualTo);
                securityWindow.WindowTitles.Add("Windows Security");
                
             
                WinEdit userName = new WinEdit(securityWindow);
                userName.SearchProperties.Add(WinEdit.PropertyNames.Name, "User name", PropertyExpressionOperator.EqualTo);
                userName.WindowTitles.Add("Windows Security");                     
                Mouse.Click(userName);            
                Keyboard.SendKeys("my username");
             
               
                WinEdit password = new WinEdit(securityWindow);
                password.SearchProperties.Add(WinEdit.PropertyNames.Name, "Password", PropertyExpressionOperator.EqualTo);            
                password.WindowTitles.Add("Windows Security");            
                Mouse.Click(password);
                Keyboard.SendKeys("my password");
    
    
                WinButton ok = new WinButton(securityWindow);
                ok.SearchProperties.Add(WinButton.PropertyNames.Name, "OK", PropertyExpressionOperator.EqualTo);            
                ok.WindowTitles.Add("Windows Security");            
                Mouse.Click(ok);
    
            }
