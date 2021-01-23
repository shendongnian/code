    String CertificatEncoded;
        String ModulusEncoded;
        String ExponentEncoded;
        RSA Cle;
        RSA ClePrivee;
        X509Certificate2 Certificat;
        public GestionCertificat(String NomCertificat)
        {
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = store.Certificates;
            X509Certificate2 cert = null;
            foreach (X509Certificate2 c in certCollection)
            {
                if (c.Subject == NomCertificat)
                {
                    cert = c;
                    break;
                }
            }
            store.Close();
            Certificat = cert;
            CertificatEncoded = Convert.ToBase64String(cert.RawData); //Conversion du certificat en base64
            RSACryptoServiceProvider rsaprovider = (RSACryptoServiceProvider)cert.PublicKey.Key;//Récupération de la clé RSA du certificat
            RSAParameters newparams = rsaprovider.ExportParameters(false);//Extractions des paramètres de la clé
            ModulusEncoded = Convert.ToBase64String(newparams.Modulus);//Conversion du Modulus en base64
            ExponentEncoded = Convert.ToBase64String(newparams.Exponent);//Conversion de l'Exponent en base64
            Cle = (RSA)cert.PublicKey.Key;
            ClePrivee = (RSA)cert.PrivateKey;
        }
        public String getCertificatEncoded()
        {
            return this.CertificatEncoded;
        }
        public String getModulusEncoded()
        {
            return this.ModulusEncoded;
        }
        public String getExponentEncoded()
        {
            return this.ExponentEncoded;
        }
        public RSA getClePublique()
        {
            return this.Cle;
        }
        public RSA getClePrivee()
        {
            return this.ClePrivee;
        }
        
        public X509Certificate2 getCertificat()
        {
            return this.Certificat;
        }
