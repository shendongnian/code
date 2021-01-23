    private async Task<AuthenticateResult> ValidateStateAsync(string state)
    {
        //Retrieve state value from TempCookie
        var authenticateResult = await this.Request
            .GetOwinContext()
            .Authentication
            .AuthenticateAsync("TempCookie");
        if (authenticateResult == null)
            throw new InvalidOperationException("No temp cookie");
        if (state != authenticateResult.Identity.FindFirst("state").Value)
            throw new InvalidOperationException("invalid state");
        return authenticateResult;
    }
