    try
    {
        //Get a recursive FTP Listing
        items = GetFtpListing(target, true);
    }
    catch(WebException e)
    {
        if (string.Equals(e.Message, "The remote server returned an error: (550) File unavailable (e.g., file not found, no access)."))
        {
            CreateRemoteDirectory(target);
            items = GetFtpListing(target, true);
        }
        else
        {
            throw e;
        }
    }
