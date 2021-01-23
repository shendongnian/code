    /// <summary>
    ///     Fetches the new cookies and saves them in the cookie jar.
    /// </summary>
    private void SaveNewCookies()
    {
        try
        {
            foreach (Cookie c in this.m_HttpWebResponse.Cookies)
            {
                if (c.Domain.Length > 0 && c.Domain[0] == '.')
                    c.Domain = c.Domain.Remove(0, 1);
                this.m_CookieJar.Add(new Uri(this.m_HttpWebResponse.ResponseUri.Scheme + "://" + c.Domain), c);
            }
            if (this.m_HttpWebResponse.Cookies.Count > 0)
                this.BugFixCookieDomain(this.m_CookieJar);
        }
        catch
        {
            // no new cookies
        }
    }
