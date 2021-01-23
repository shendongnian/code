    string publicRSAKey = null;
    string publicPlusPrivateRSAKey = null;
    
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
    	publicRSAKey = rsa.ToXmlString(false);
    }
    
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
    	publicPlusPrivateRSAKey = rsa.ToXmlString(true);
    }
