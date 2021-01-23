    string finalurl = null;
    string url = "http://test.com/attachment.php?s=21c4a95ffd0c8110e18a44ace2468fb3&amp;attachmentid=85411&amp;d=1432094822";
    Uri uri;
    if(Uri.TryCreate(url, UriKind.Absolute, out uri))
    {
        var queryString = url.Substring(url.IndexOf('?')).Split('#')[0];
        string decoded = System.Web.HttpUtility.HtmlDecode(queryString);
        var nameVals = System.Web.HttpUtility.ParseQueryString(decoded);
        nameVals.Remove("s"); // remove your undesired parameter
        finalurl = String.Format("{0}{1}{2}{3}?{4}"
                , uri.Scheme, Uri.SchemeDelimiter, uri.Authority, uri.AbsolutePath
                , nameVals.ToString());
    }
