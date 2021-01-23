    using System;
    using System.Security.Cryptography.X509Certificates;
    using bcrypto = Org.BouncyCastle.X509;
.
    var cert = new X509Certificate2("c:\\temp\\0c50000343119659.cer");
    var certParser = new bcrypto.X509CertificateParser();
    var privateCertBouncy = certParser.ReadCertificate(cert.GetRawCertData());
    var xx = privateCertBouncy.GetSignature();
    var asndata = new System.Security.Cryptography.AsnEncodedData(privateCertBouncy.SigAlgOid, privateCertBouncy.GetSignature());
    //signature
    Console.WriteLine(asndata.Format(true));
    //alghoritm
    Console.WriteLine(privateCertBouncy.SigAlgName);
