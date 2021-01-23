    public WebException createExceptionHelper(String message, WebExceptionStatus webExceptionStatus, FtpStatusCode serverError )
    {
        var ftpWebResponse = Rhino.Mocks.MockRepository.GenerateStub<FtpWebResponse>();
        ftpWebResponse.Stub(f => f.StatusCode).Return(serverError);
        ftpWebResponse.Stub(f => f.ResponseUri).Return(new Uri("http://mock.localhost"));
    
        //now just pass the ftpWebResponse stub object to the constructor
        return new WebException(message, null, webExceptionStatus, ftpWebResponse);
        }
