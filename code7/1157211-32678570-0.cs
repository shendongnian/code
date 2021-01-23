    public void SignEmail( MimeMessage m, Org.BouncyCastle.X509.X509Certificate certificate, Org.BouncyCastle.Crypto.AsymmetricKeyParameter key, MailboxAddress sender, MimeEntity content)
        {
            var signer = new MimeKit.Cryptography.CmsSigner( certificate, key );
            signer.DigestAlgorithm = DigestAlgorithm.Sha1;
            m.Body = ApplicationPkcs7Mime.Sign( sender, signer.DigestAlgorithm, content );
        }
