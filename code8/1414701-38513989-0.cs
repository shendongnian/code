    public void FileAttachment()
    {
            PageObjects.UploadFile.Click();
            Driver.Instance.FindElement(By.XPath("//*@id='fileUpload']div")).Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActive("Open"); //Differs from Browser to Browser
            autoIt.Send(@"C:Desktop\doccs\trialTest.txt");
            autoIt.Send("{ENTER}");
            Thread.Sleep(1000);
            PageObjects.FileUploadSend.Click();
    }
