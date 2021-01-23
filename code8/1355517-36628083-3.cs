    private void SendVerificationEmail(string emailAddress, string token)
    {
        try
        {
            // Url.Action will encode parameters as they are needed.
            var verificationUrl = Url.Action("VerifyAccount", "Account", new { token = token }, Request.Url.Scheme);
            _userMailer.DeliverVerification(emailAddress, verificationUrl);
        }
        catch (Exception ex)
        {
            _logger.ErrorLog.Log(new VerificationError(ex));
        }
    }
