    IWebElement myLink = driver.FindElementSafe(By.Id("myId"));
    if (myLink.Exists)
    {
       Console.Write("Priviledges is working ");
    }
    else{
           Console.Write("Priviledges is not working ");
    }
