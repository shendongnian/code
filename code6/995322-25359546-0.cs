    using namespace System::Net;
    using namespace System::Net::Security;
    using namespace System::Security::Cryptography::X509Certificates;
    bool returnTrueCallback(
    	Object^ sender, X509Certificate^ certificate, X509Chain^ chain,
    	SslPolicyErrors sslPolicyErrors)
    {
    	return true;
    }
    
    ...
    
    ServicePointManager::ServerCertificateValidationCallback =
        gcnew RemoteCertificateValidationCallback(returnTrueCallback);
