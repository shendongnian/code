    using System;
    using System.Security.Cryptography.X509Certificates;
    using bcrypto = Org.BouncyCastle.X509;
.
            var cert = new X509Certificate2("c:\\temp\\0c50000343119659.cer");
            bcrypto.X509CertificateParser certParser = new bcrypto.X509CertificateParser();
            bcrypto.X509Certificate privateCertBouncy = certParser.ReadCertificate(cert.GetRawCertData());
            var xx = privateCertBouncy.GetSignature();
            System.Security.Cryptography.AsnEncodedData asndata = new System.Security.Cryptography.AsnEncodedData(privateCertBouncy.SigAlgOid, privateCertBouncy.GetSignature());
    //signature
            Console.WriteLine(asndata.Format(true));
    //alghoritm
            Console.WriteLine(privateCertBouncy.SigAlgName);
