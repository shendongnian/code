    /*
        using CERTADMINLib;
        using CERTCLILib;
        using CertSevAPI.Core.Models;
        using CertSrvAPI.Core;
        using CertSrvAPI.Core.Models;
        using Org.BouncyCastle.Asn1;
        using Org.BouncyCastle.Asn1.Pkcs;
        using Org.BouncyCastle.Asn1.X509;
        using Org.BouncyCastle.Crypto;
        using Org.BouncyCastle.Crypto.Generators;
        using Org.BouncyCastle.Crypto.Prng;
        using Org.BouncyCastle.Pkcs;
        using Org.BouncyCastle.Security;
        using System;
    */
    
    var caService = new CAService();
    
    // Create a certificate request.
    // The private key is here.
    var caRequest = caService.CertRequest(subjectDN);
    
    // Submit the certificate request and get the response.
    var caResponse = caService.SendCertRequest(caRequest.Request);
    
    // If certificated is not issued return null.
    if (!caService.IsIssued(caResponse.Disposition))
    {
        return null;
    }
    
    // Download the P7B file from CA.
    var p7b = new WebClient().DownloadData(
        _appSettings.CERT_SRV + "/CertSrv/CertNew.p7b?ReqID=" + caResponse.CertRequest.GetRequestId() + "&Enc=bin");
    
    try
    {
        var certCollection = new X509Certificate2Collection();
        
        // Import the downloaded file.
        certCollection.Import(p7b);
    
        // Create a PKCS store.
        var pfx = new Pkcs12Store();
        
        // Insert root CA certificate into the PKCS store.
        pfx.SetCertificateEntry("rootCert",
            new X509CertificateEntry(DotNetUtilities.FromX509Certificate(certCollection[0])));
    
        // Get the second certificate from the downloaded file.
        // That one is the generated certificate for our request.
        var certificateEntry = new X509CertificateEntry[1];
        certificateEntry[0] = new X509CertificateEntry(DotNetUtilities.FromX509Certificate(certCollection[1]));
        
        // Insert our certificate with the private key
        // under the same alias so then we know that this private key
        // is for our certificate.
        pfx.SetKeyEntry("taxkey", new AsymmetricKeyEntry(caRequest.PrivateKey), certificateEntry);
    
        var memoryStream = new MemoryStream();
        
        // Stream PFX store using the desired password
        // for our file.
        pfx.Save(memoryStream, password.ToCharArray(), new SecureRandom());
       
        var pfxBytes = memoryStream.GetBuffer();
        pfxBytes = Pkcs12Utilities.ConvertToDefiniteLength(pfxBytes, password.ToCharArray());
    
        // Here you can save the pfxBytes to a file, if you want.
        // Actually I needed it to give as a response in MVC application.
        return File(pfxBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "NewCert.pfx");
    }
    catch (Exception ex)
    {
        // If there is an error remove private key from
        // the memory.
        caRequest.PrivateKey = null;
        caRequest.Request = null;
    
        ErrorSignal.FromCurrentContext().Raise(ex);
    
        if (showError != null && showError.ToLower() == "true")
        {
            throw ex;
        }
    
        return null;
    }
