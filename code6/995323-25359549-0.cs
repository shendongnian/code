    using namespace System;
    using namespace System::Net;
    using namespace System::Net::Security;
    using namespace System::Security::Cryptography::X509Certificates;
    
    
    static bool ValidateServerCertificate(
            Object^ sender,
            X509Certificate^ certificate,
            X509Chain^ chain,
            SslPolicyErrors sslPolicyErrors)
        {
    		return true;
        }
    
    int main(array<System::String ^> ^args)
    {
        // create callback object, pointing to your function
    	System::Net::Security::RemoteCertificateValidationCallback^ clb = gcnew RemoteCertificateValidationCallback(ValidateServerCertificate);
        // assign it to the property
    	System::Net::ServicePointManager::ServerCertificateValidationCallback = clb;
    
        return 0;
    }
