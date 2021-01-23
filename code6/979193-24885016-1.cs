    try
    {
        FtpWebResponse response = (FtpWebResponse) request.GetResponse();
    }
    catch (WebException ex)
    {
        if (ex.Response != null)
            Console.WriteLine(((FtpWebResponse)ex.Response).StatusDescription);
    }
