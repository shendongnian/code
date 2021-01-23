    private ListsSoapClient CreateListsSoapClient(string siteUrl, string siteUserName, string sitePassword)
		{			
			var basicHttpBinding = new BasicHttpBinding
			{
				CloseTimeout = new TimeSpan(00, 5, 00),
				OpenTimeout = new TimeSpan(00, 5, 00),
				ReceiveTimeout = new TimeSpan(00, 5, 00),
				SendTimeout = new TimeSpan(00, 5, 00),
				TextEncoding = Encoding.UTF8,
				MaxReceivedMessageSize = int.MaxValue,
				MaxBufferSize = int.MaxValue,
				Security =
				{
					Mode = BasicHttpSecurityMode.TransportCredentialOnly
				},
				ReaderQuotas =
				{
					MaxArrayLength = int.MaxValue,
					MaxBytesPerRead = int.MaxValue,
					MaxStringContentLength = int.MaxValue
				}
			};
			basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;					
			var url = string.Format("{0}/_vti_bin/Lists.asmx", siteUrl);
			var address = new EndpointAddress(url);
			var listsSoapClient = new ListsSoapClient(basicHttpBinding, address);
			
			listsSoapClient.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Delegation;
			listsSoapClient.ChannelFactory.Credentials.Windows.ClientCredential = new NetworkCredential(siteUserName, sitePassword);
			listsSoapClient.ChannelFactory.Credentials.Windows.AllowNtlm = true;
			return listsSoapClient;
		}
