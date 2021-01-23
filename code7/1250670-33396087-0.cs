    protected override WebResponse GetWebResponse(WebRequest request)
    {
        WebRequest deepCopiedWebRequest = ObjectCopier.Clone<WebRequest>(request);
        try
        {
            return base.GetWebResponse(deepCopiedWebRequest);
        }
        catch (WebException ex)
        {
            if(ex.Status == WebExceptionStatus.Timeout || ex.Status == WebExceptionStatus.ConnectFailure)
            if (--Tries == 0)
                throw;
            GetWebResponse(request);
        }
    }
