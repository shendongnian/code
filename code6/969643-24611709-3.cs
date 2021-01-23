    [__DynamicallyInvokable]
    public string Authority
    {
      [__DynamicallyInvokable] get
      {
        if (this.IsNotAbsoluteUri)
          throw new InvalidOperationException(System.SR.GetString("net_uri_NotAbsolute"));
        else
          return this.GetParts(UriComponents.Host | UriComponents.Port, UriFormat.UriEscaped);
      }
    }
