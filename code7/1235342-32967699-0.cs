    IAsyncResult connectResult = this._client.BeginConnectSsl(imapClientSettings.Host, imapClientSettings.Port, null);
    if (!result.AsyncWaitHandle.WaitOne(this._connectionTimeout))
    {
        throw new EmailTimeoutException(this._connectionTimeout);
    }
