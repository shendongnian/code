    string publicRSAKey = null;
    string publicPlusPrivateRSAKey = null;
    
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
		publicRSAKey = rsa.ToXmlString(false);
		publicPlusPrivateRSAKey = rsa.ToXmlString(true);
	}
