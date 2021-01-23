    public WebException createExceptionHelper(String message, WebExceptionStatus serverError )
    {
        var ftpWebResponse = Rhino.Mocks.MockRepository.GenerateStub<FtpWebResponse>();
        ftpWebResponse.Stub(f => f.StatusCode).Return(serverError);
            
        //now just pass the ftpWebResponse stub object to the constructor
        return new WebException(message, null, WebExceptionStatus.ProtocolError, ftpWebResponse);
    }
