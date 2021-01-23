    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            ...
    
            var isValid = await this.IsValidRequest(req, appId, incomingBase64Signature, nonce, requestTimeStamp);
    
            if (isValid)
            {
                ...
            }
            ...
        }
