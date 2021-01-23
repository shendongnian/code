     public void AcceptAlert()
     {
            IAlert alert = GetAlert();
            alert.Accept();
            WaitForPageLoading(); //this implement by yourself
     }
    
     public IAlert GetAlert()
     {
            try
            {
                 IAlert alert = Driver.SwitchTo().Alert();
                 return alert;
            }
            catch (NoAlertPresentException)
            {
                 // no alert to dismiss, so return null
                 return null;
            }
    }
