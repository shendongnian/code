    string yourPreviousUrl = Request.UrlReferrer.ToString();
    
    if(!string.IsNullOrEmpty(yourPreviousUrl))
    {
        //Referrer was found!
    }
    else
    {
        //Unable to detect a Referrer
    }
