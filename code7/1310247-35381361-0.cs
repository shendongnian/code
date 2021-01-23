     var app = ApplicationUnderTest.Launch(@"yourapplication.exe");
     var mainWindow = new WinWindow(app);
     mainWindow.WindowTitles.Add("Form1");
         
     WinText textLabel = new WinText(mainWindow);
     textLabel.SearchProperties.Add(WinControl.PropertyNames.Name, "Some Text Label");
     WinEdit siblingEditControl = new WinEdit(textLabel);
     siblingEditControl.SearchConfigurations.Add(SearchConfiguration.NextSibling);
     siblingEditControl.Text = "setting the text";
