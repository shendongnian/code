    public sealed class SslTcpProxy
    {
        static void Main(String[] args)
        {
            // Create a TCP/IP (IPv4) socket and listen for incoming connections.
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 443);
            tcpListener.Start();
            Console.WriteLine("Server listening on 127.0.0.1:433  Press enter to exit.");
            Console.WriteLine();
            Console.WriteLine("Waiting for a client to connect...");
            Console.WriteLine();
            // Application blocks while waiting for an incoming connection.
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            AcceptConnection(tcpClient);
            Console.ReadLine();
            tcpListener.Stop();
        }
        private static void AcceptConnection(TcpClient client)
        {
            try
            {
                // Using a pre-created certificate.
                String certFilePath = Environment.CurrentDirectory + @"\certificates\server-cert.pfx";
                X509Certificate2 certificate;
                try
                {
                    certificate = new X509Certificate2(certFilePath, "[CER_PASSWORD]");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not create the certificate from file from {certFilePath}", ex);
                }
                SslStream clientSslStream = new SslStream(client.GetStream(), false);
                clientSslStream.AuthenticateAsServer(certificate, false, SslProtocols.Default, false);
                // Display the properties and settings for the authenticated as server stream.
                Console.WriteLine("clientSslStream.AuthenticateAsServer");
                Console.WriteLine("------------------------------------");
                DisplaySecurityLevel(clientSslStream);
                DisplaySecurityServices(clientSslStream);
                DisplayCertificateInformation(clientSslStream);
                DisplayStreamProperties(clientSslStream);
                Console.WriteLine();
                // The Ip address of the server we are trying to connect to.
                // Dont use the URI as it will resolve from the host file.
                TcpClient server = new TcpClient("[SERVER_IP]", 443);
                SslStream serverSslStream = new SslStream(server.GetStream(), false, SslValidationCallback, null);
                serverSslStream.AuthenticateAsClient("[SERVER_NAME]");
                // Display the properties and settings for the authenticated as server stream.
                Console.WriteLine("serverSslStream.AuthenticateAsClient");
                Console.WriteLine("------------------------------------");
                DisplaySecurityLevel(serverSslStream);
                DisplaySecurityServices(serverSslStream);
                DisplayCertificateInformation(serverSslStream);
                DisplayStreamProperties(serverSslStream);
                new Task(() => ReadFromClient(client, clientSslStream, serverSslStream)).Start();
                new Task(() => ReadFromServer(serverSslStream, clientSslStream)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private static Boolean SslValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }
        private static void ReadFromServer(Stream serverStream, Stream clientStream)
        {
            Byte[] message = new Byte[4096];
            while (true)
            {
                Int32 serverBytes;
                try
                {
                    serverBytes = serverStream.Read(message, 0, BufferSize);
                    clientStream.Write(message, 0, serverBytes);
                }
                catch
                {
                    break;
                }
                if (serverBytes == 0)
                {
                    break;
                }
            }
        }
        private static void ReadFromClient(TcpClient client, Stream clientStream, Stream serverStream)
        {
            Byte[] message = new Byte[BufferSize];
            FileInfo fileInfo = new FileInfo("client");
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Dispose();
            }
            using (FileStream stream = fileInfo.OpenWrite())
            {
                while (true)
                {
                    Int32 clientBytes;
                    try
                    {
                        clientBytes = clientStream.Read(message, 0, BufferSize);
                    }
                    catch
                    {
                        break;
                    }
                    if (clientBytes == 0)
                    {
                        break;
                    }
                    serverStream.Write(message, 0, clientBytes);
                    stream.Write(message, 0, clientBytes);
                }
                client.Close();
            }
        }
        static void DisplaySecurityLevel(SslStream stream)
        {
            Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength);
            Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength);
            Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
            Console.WriteLine("Protocol: {0}", stream.SslProtocol);
        }
        static void DisplaySecurityServices(SslStream stream)
        {
            Console.WriteLine("Is authenticated: {0} as server? {1}", stream.IsAuthenticated, stream.IsServer);
            Console.WriteLine("IsSigned: {0}", stream.IsSigned);
            Console.WriteLine("Is Encrypted: {0}", stream.IsEncrypted);
        }
        static void DisplayStreamProperties(SslStream stream)
        {
            Console.WriteLine($"Can read: {stream.CanRead}, write {stream.CanWrite}");
            Console.WriteLine($"Can timeout: {stream.CanTimeout}");
        }
        static void DisplayCertificateInformation(SslStream stream)
        {
            Console.WriteLine($"Certificate revocation list checked: {stream.CheckCertRevocationStatus}");
            X509Certificate localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null)
            {
                Console.WriteLine("Local cert was issued to {0} and is valid from {1} until {2}.",
                    localCertificate.Subject,
                    localCertificate.GetEffectiveDateString(),
                    localCertificate.GetExpirationDateString());
            }
            else
            {
                Console.WriteLine("Local certificate is null.");
            }
            // Display the properties of the client's certificate.
            X509Certificate remoteCertificate = stream.RemoteCertificate;
            if (stream.RemoteCertificate != null)
            {
                if (remoteCertificate != null)
                {
                    Console.WriteLine(
                        $"Remote cert was issued to {remoteCertificate.Subject} and is valid from {remoteCertificate.GetEffectiveDateString()} until {remoteCertificate.GetExpirationDateString()}.");
                }
            }
            else
            {
                Console.WriteLine("Remote certificate is null.");
            }
        }
    }
