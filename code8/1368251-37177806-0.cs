        private async Task<bool> RequestCertificateAccess(Certificate cert)
        {
            bool signOK = false;
            try
            {
                IBuffer data = CryptographicBuffer.ConvertStringToBinary("ABCDEFGHIJKLMNOPQRSTUVWXYZ012345656789", 
                    BinaryStringEncoding.Utf8);
                CryptographicKey key = await PersistedKeyProvider.OpenKeyPairFromCertificateAsync(cert,
                    HashAlgorithmNames.Sha1, CryptographicPadding.RsaPkcs1V15);
                IBuffer sign = await CryptographicEngine.SignAsync(key, data);
                signOK = CryptographicEngine.VerifySignature(key, data, sign);
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString(), "Certificate access denied or sign/verify failure.");
                signOK = false;
            }
            return signOK;
        }
