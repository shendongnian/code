		static public byte[] PKCS7SignMessage(byte[] manifest_data, X509Certificate2 signerCertificate) {
			X509Certificate2Collection ca_chain;
			ContentInfo content;
			SignedCms signed_cms;
			CmsSigner signer;
			signed_cms = new SignedCms();
			ca_chain = new X509Certificate2Collection(new X509Certificate2(@"Path-to-new-intermediate-WWRD.cer"));
			content = new ContentInfo(manifest_data);
			signed_cms = new SignedCms(content, true);
			signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, signerCertificate);
			signer.IncludeOption = X509IncludeOption.ExcludeRoot;
			signer.Certificates.AddRange(ca_chain);
			signed_cms.ComputeSignature(signer);
			return signed_cms.Encode();
		}
