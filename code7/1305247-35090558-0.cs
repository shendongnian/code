    TcpClient _client;
    NetworkStream _stream;
	public TcpClient ProxyTcpClient(string targetHost, int targetPort, string httpProxyHost, int httpProxyPort, string proxyUserName, string proxyPassword)
    {
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Instance;
            Uri proxyUri = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttp,
                Host = httpProxyHost,
                Port = httpProxyPort
            }.Uri;
            Uri targetUri = new UriBuilder
            {
                 Scheme = Uri.UriSchemeHttp,
                 Host = targetHost,
                 Port = targetPort
            }.Uri;
            WebProxy webProxy = new WebProxy(proxyUri, true);
            webProxy.Credentials = new NetworkCredential(proxyUserName, proxyPassword);
            WebRequest request = WebRequest.Create(targetUri);
            request.Proxy = webProxy;
            request.Method = "CONNECT";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            Type responseType = responseStream.GetType();
            PropertyInfo connectionProperty = responseType.GetProperty("Connection", Flags);
            var connection = connectionProperty.GetValue(responseStream, null);
            Type connectionType = connection.GetType();
            PropertyInfo networkStreamProperty = connectionType.GetProperty("NetworkStream", Flags);
            NetworkStream networkStream = (NetworkStream)networkStreamProperty.GetValue(connection, null);
            Type nsType = networkStream.GetType();
            PropertyInfo socketProperty = nsType.GetProperty("Socket", Flags);
            Socket socket = (Socket)socketProperty.GetValue(networkStream, null);
            return new TcpClient { Client = socket };
    }
		
	public static async Task<bool> ConnectAsync(string hostname, int port)
	{
			_client = ProxyTcpClient("IPTargetHost", 1234, "IPProxyHost", 5678, "Userproxy", "Userppwd");
			_stream = conn._client.GetStream();
			..... Do some stuff
			// Connexion OK
			return true;
    }
	
	
	
