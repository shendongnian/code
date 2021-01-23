    DerSequence publicKeySequence = (DerSequence)obj;
    DerBitString encodedPublicKey = (DerBitString)publicKeySequence[1];
    DerSequence publicKey = (DerSequence)Asn1Object.FromByteArray(encodedPublicKey.GetBytes());
    DerInteger modulus = publicKey[0];
    DerInteger exponent = publicKey[1];
