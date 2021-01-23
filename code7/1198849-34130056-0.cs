    var filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
    filter.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.Expired);
    filter.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.Untrusted);
    filter.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.InvalidName);
    using (var client = new Windows.Web.Http.HttpClient(filter))
        {
            Uri uri = new Uri("https://yourwebsite.com");
        }
