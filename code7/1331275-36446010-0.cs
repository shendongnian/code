        /// <summary>
        ///     Make attached signature.
        /// </summary>
        public byte[] SignAttached(X509Certificate2 certificate, byte[] dataToSign)
        {
            ContentInfo contentInfo = new ContentInfo(dataToSign);
            SignedCms cms = new SignedCms(contentInfo, false);
            CmsSigner signer = new CmsSigner(certificate);
            cms.ComputeSignature(signer, false);
            return cms.Encode();
        }
        /// <summary>
        ///     Make detached signature.
        /// </summary>
        public byte[] SignDetached(X509Certificate2 certificate, byte[] dataToSign)
        {
            ContentInfo contentInfo = new ContentInfo(dataToSign);
            SignedCms cms = new SignedCms(contentInfo, true);
            CmsSigner signer = new CmsSigner(certificate);
            cms.ComputeSignature(signer, false);
            return cms.Encode();
        }
