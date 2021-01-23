    public class SSHConnection
        {
            public SSHConnection() { }
        public ConnectionInfo makeSSHConnection(string ipAdress, int port, string user, string pwd)
        {
            ConnectionInfo ConnNfo = new ConnectionInfo(ipAdress, port, user,
              new AuthenticationMethod[]{
                // Pasword based Authentication
                new PasswordAuthenticationMethod(user,pwd),
              }
                 );
            return ConnNfo;
        }
    }
