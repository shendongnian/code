    foreach (CryptographicAttributeObject cryptoAttribute in primarySigner.UnsignedAttributes)
    {
        if (cryptoAttribute.Oid.Value == szOID_RFC3161_TIMESTAMP.Value)
        {
            Pkcs9AttributeObject rfcTimestampObj = new Pkcs9AttributeObject(cryptoAttribute.Values[0]);
            //Decode the attribute
            SignedCms rfcTimestampMessage = new SignedCms();
            rfcTimestampMessage.Decode(rfcTimestampObj.RawData);
            //At this point you are obtained the timestamp message as a SignedCMS object - rfcTimestampMessage.SignerInfos.Count > 1
        }
    }
