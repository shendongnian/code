    if (AppendVersion == true)
    {
        EnsureFileVersionProvider();
        if (Href != null)
        {
            output.Attributes[HrefAttributeName].Value = _fileVersionProvider.AddFileVersionToPath(Href);
        }
    }
    private void EnsureFileVersionProvider()
    {
        if (_fileVersionProvider == null)
        {
            _fileVersionProvider = new FileVersionProvider(
                    HostingEnvironment.WebRootFileProvider,
                    Cache,
                    ViewContext.HttpContext.Request.PathBase);
        }
    }
