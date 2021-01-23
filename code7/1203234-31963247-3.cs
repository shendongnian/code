    public class FtpDistributor : IDistributor
    {
        private FtpAccountRepository _repository = new FtpAccountRepository();
        private FtpClient _client = new FtpClient();
    
        public void Distribute(string userName, byte[] file)
        {
            var ftpAccount = _repository.GetAccount(userName);
            _client.Connect(ftpAccount.Host);
            _client.Authenticate(ftpAccount.userName, ftpAccount.Password);
            _Client.Send(file);
        }
    }
