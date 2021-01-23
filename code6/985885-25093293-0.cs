    public void UpdateCell (string subtitle2)
    {
        //Makes a new NSUrl
        var callURL = new NSUrl("tel:" + subtitle2);
               
        call.SetTitle(subtitle2, UIControlState.Normal);
        call.TouchUpInside += (object sender, EventArgs e) => {
        if (UIApplication.SharedApplication.CanOpenUrl (callURL)) {
        //After checking if phone can open NSUrl, it either opens the URL or outputs to the console.
            UIApplication.SharedApplication.OpenUrl(callURL);
        } else {
        //OUTPUT to console
        Console.WriteLine("Can't make call");
        }
      };          
    }
