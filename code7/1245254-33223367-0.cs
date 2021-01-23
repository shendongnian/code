        using System.Security.Cryptography.X509Certificates;
        
        namespace Name {
    	    class Class1 {
    		public static X509Certificate2 GetIssuer(X509Certificate2 leafCert) {
    			if (leafCert.Subject == leafCert.Issuer) { return leafCert; }
    			X509Chain chain = new X509Chain();
    			chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    			chain.Build(leafCert);
    			X509Certificate2 issuer = null;
    			if (chain.ChainElements.Count > 1) {
    				issuer = chain.ChainElements[1].Certificate;
    			}
    			chain.Reset();
    			return issuer;
    		}
    	}
        }
