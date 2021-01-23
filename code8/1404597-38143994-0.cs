    public class MyWebClient : WebClient
	{
        X509Certificate2 certificate;
		public MyWebClient(X509Certificate2 certificate)
			: base()
		{
			this.certificate = certificate;
		}
		protected override WebRequest GetWebRequest(Uri address)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
			request.ClientCertificates.Add(certificate);
			request.Credentials = this.Credentials;
			return request;
		}
	}
