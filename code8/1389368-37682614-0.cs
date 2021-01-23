     public static void CatchAlertAndAccept(IWebDriver d, bool isAccept)
        {
            IAlert simpleAlert = d.SwitchTo().Alert();
            if (isAccept == true)
            {
                simpleAlert.Accept();
            }
            else
            {
                simpleAlert.Dismiss();
            }
        }
