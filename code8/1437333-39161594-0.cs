            public static void UploadDocument(this IWebDriver driver, IWebElement button)
        {
            string idPath = Path.Combine("C:/", ""); //can be whatever
            button.WaitFor(driver);
            button.MoveAndClick(driver);
            CommonMethods.WaitOnAPage(1); //simple wait method
            SendKeys.SendWait(@idPath);
            CommonMethods.WaitOnAPage(1);//simple wait method
            SendKeys.SendWait(@"{Enter}"); //enter button 
            CommonMethods.WaitOnAPage(1);//simple wait method
            
        }
