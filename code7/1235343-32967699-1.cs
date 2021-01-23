    IAsyncResult connectResult = this._client.BeginConnectSsl(imapClientSettings.Host, imapClientSettings.Port, null);
    if (!connectResult.AsyncWaitHandle.WaitOne(this._connectionTimeout))
    {
        throw new EmailTimeoutException(this._connectionTimeout);
    }
