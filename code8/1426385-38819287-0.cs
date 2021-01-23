    string PendT;
    webBrowser1.Document.GetElementById("ctl00_cphRoblox_JoinGroup").InvokeMember("click");
    HtmlElement Pend =  webBrowser1.Document.GetElementById("ctl00_cphRoblox_AlreadyRequestedInvite");
    
    if(Pend != null)
    {
      PendT = Pend.InnerText;
      Debug.WriteLine(PendT);
    
      if (PendT == "Join Pending")
      {
        Debug.WriteLine("Join Pending");
        Value = 1;
      }
    }
    else
    {
      // do something here
    }
