    using System;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                X509Store certStore = null;
                X509Certificate2 signingCertificate = null;
    
                // Select signing certificate
                try
                {
                    certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    certStore.Open(OpenFlags.ReadOnly);
    
                    X509Certificate2Collection certCollection = X509Certificate2UI.SelectFromCollection(certStore.Certificates, null, null, X509SelectionFlag.SingleSelection);
                    if (certCollection == null || certCollection.Count < 1)
                        throw new Exception("No certificate selected");
    
                    signingCertificate = certCollection[0];
                    if (!signingCertificate.HasPrivateKey)
                        throw new Exception("Selected certificate is not associated with a private key");
                }
                finally
                {
                    if (certStore != null)
                        certStore.Close();
                }
    
                // Create CMS signature with selected certificate
                byte[] dataToSign = Encoding.UTF8.GetBytes("Hello world");
                ContentInfo contentInfo = new ContentInfo(dataToSign);
                CmsSigner cmsSigner = new CmsSigner(signingCertificate);
                SignedCms signedCms = new SignedCms(contentInfo, false);
                signedCms.ComputeSignature(cmsSigner);
                byte[] signature = signedCms.Encode();
    
                // Parse and verify CMS signature (without certification path checking)
                SignedCms signedCms2 = new SignedCms();
                signedCms2.Decode(signature);
                signedCms2.CheckSignature(true);
            }
        }
    }
