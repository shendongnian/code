    class DisposableSmtpClient : SmtpClient, IDisposable
    {
        public DisposableSmtpClient(string mailServer, int port) : base(mailServer, port)
        {
        }
    
        public void Dispose()
        {
            // anything to do, so don't do anything.
        }
    }
