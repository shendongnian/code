    using System;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    
    namespace MyNamespace {
    	class MyClass {
    		Boolean ServerCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
    			String rootCAThumbprint = ""; // write your code to get your CA's thumbprint
    
    			// remove this line if commercial CAs are not allowed to issue certificate for your service.
    			if ((sslPolicyErrors & (SslPolicyErrors.None)) > 0) { return true; }
    
    			if (
    				(sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNameMismatch)) > 0 ||
    				(sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNotAvailable)) > 0
    			) { return false; }
    			// get last chain element that should contain root CA certificate
    			// but this may not be the case in partial chains
    			X509Certificate2 projectedRootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
    			if (projectedRootCert.Thumbprint != rootCAThumbprint) {
    				return false;
    			}
    			// execute certificate chaining engine and ignore only "UntrustedRoot" error
    			X509Chain customChain = new X509Chain {
    				ChainPolicy = {
    					VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority
    				}
    			};
    			Boolean retValue = customChain.Build(chain.ChainElements[0].Certificate);
    			// RELEASE unmanaged resources behind X509Chain class.
    			chain.Reset();
    			return retValue;
    		}
    	}
    }
