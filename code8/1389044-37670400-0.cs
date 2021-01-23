    public Uri UrlReferrer
    {
        get
        {
            if ((this._referrer == null) && (this._wr != null))
            {
                string knownRequestHeader = this._wr.GetKnownRequestHeader(0x24);
                if (!string.IsNullOrEmpty(knownRequestHeader))
                {
                    try
                    {
                        if (knownRequestHeader.IndexOf("://", StringComparison.Ordinal) >= 0)
                        {
                            this._referrer = new Uri(knownRequestHeader);
                        }
                        else
                        {
                            this._referrer = new Uri(this.Url, knownRequestHeader);
                        }
                    }
                    catch (HttpException)
                    {
                        this._referrer = null;
                    }
                }
            }
            return this._referrer;
        }
    }
