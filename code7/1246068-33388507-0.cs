	  private static bool m_isHomeLocation = false;
	  public static bool IsHomeLocation
      {
          get
          {
              if (m_isHomeLocation)
                  return true;
              try
              {
                  HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yourLicenseServer:yourConfiguredPort");
                  request.ServerCertificateValidationCallback += ((s, certificate, chain, sslPolicyErrors) => true);
                  HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                  response.Close();
                  var thumbprint = new X509Certificate2(request.ServicePoint.Certificate).Thumbprint;
                  m_isHomeLocation = (thumbprint == "WhateverThumbprintYourCertificateHave");                    
              }
              catch
              {
                  // pass - maybe next time
              }
              return m_isHomeLocation;
          }
      }
