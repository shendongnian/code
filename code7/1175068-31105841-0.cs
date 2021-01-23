    public class RemotePc {
        public RemotePc(string _ServerName, string _UserName, string _Password) {
            ServerName = _ServerName;
            UserName = _UserName;
            Password = _Password;
        }
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
