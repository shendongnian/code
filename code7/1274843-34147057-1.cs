    /*
     * Http status description string
     */
 
    // Http status description string
    //    Gets or sets the HTTP status string of output returned to the client.
    public String StatusDescription {
        get {
            if (_statusDescription == null)
                _statusDescription = HttpWorkerRequest.GetStatusDescription(_statusCode);
 
            return _statusDescription;
        }
 
        set {
            if (_headersWritten)
                throw new HttpException(SR.GetString(SR.Cannot_set_status_after_headers_sent));
 
            if (value != null && value.Length > 512)  // ASURT 124743
                throw new ArgumentOutOfRangeException("value");
            _statusDescription = value;
            _statusSet = true;
        }
    }
