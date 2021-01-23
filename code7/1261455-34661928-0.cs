            var IP = "127.0.0.1";
            var Port = "12345";
            
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Transport;
            b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            EndpointAddress ea = new EndpointAddress(new Uri("net.tcp://" + IP + ":" + Port + "/MyService"));
            var client = new ServiceReference1.MyServiceClient(b, ea);
            client.Endpoint.Address = new EndpointAddress(new Uri("net.tcp://" + IP + ":" + Port + "/MyService"));
            client.ClientCredentials.Windows.ClientCredential.UserName = TB_UserName.Text;
            client.ClientCredentials.Windows.ClientCredential.Password = TB_Password.Text;
