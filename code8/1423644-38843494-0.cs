    var filter = new HttpBaseProtocolFilter();
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
    var http = new HttpClient(filter);
