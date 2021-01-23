    Install-Package BouncyCastle
      //reference library BouncyCastle.Crypto
      //http://www.bouncycastle.org/csharp/
      //Load CRL file and access its properties
        public void  GetCrlInfo(string fileName, Org.BouncyCastle.Math.BigInteger serialNumber, Org.BouncyCastle.X509.X509Certificate cert)
        {
            try
            {
                byte[] buf = ReadFile(fileName);
                X509CrlParser xx = new X509CrlParser();
                X509Crl ss = xx.ReadCrl(buf);
                var nextupdate = ss.NextUpdate;
                var isRevoked = ss.IsRevoked(cert);
                Console.WriteLine("{0} {1}",nextupdate,isRevoked);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
