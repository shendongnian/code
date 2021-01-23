      byte[] data = Encoding.ASCII.GetBytes(strbody);
      ContentInfo content = new ContentInfo(data);
      SignedCms signedCms = new SignedCms(content, false);
      CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);      
      signedCms.ComputeSignature(signer);
      byte[] signedbytes = signedCms.Encode();      
