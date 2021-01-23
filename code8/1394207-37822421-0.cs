    using System;
    using System.Net;
    using NuGet;
    
    namespace Test
    {
    	class MyCredentialProvider : ICredentialProvider
    	{
    		public ICredentials GetCredentials(Uri uri, IWebProxy proxy, CredentialType credentialType, bool retrying)
    		{
    			// TODO return the credentials...
                throw new NotImplementedException ();
    		}
    	}
    }
