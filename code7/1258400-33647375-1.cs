    static void Main(string[] args)
    {
        string expectedSubjectName = "My Application";
        X509Certificate2 issuerCertificate = new X509Certificate2(Resource1.IssuerCertificate);
        string expectedIssuerName = issuerCertificate.Subject;
        bool result = VerifyCertificateIssuer(expectedSubjectName, expectedIssuerName, issuerCertificate);
    }
    private static void ThrowCertificateNotFoundException(string expectedSubjectName, string expectedIssuerName, bool isThumbprintMismatch)
    {
        if (isThumbprintMismatch)
        {
            // Notification for possible certificate forgery
        }
        throw new SecurityException("A certificate with subject name " + expectedSubjectName + " issued by " + expectedIssuerName + " is required to run this application");
    }
    private static X509Certificate2 GetCertificate(string expectedSubjectName, string expectedIssuerName)
    {
        X509Store personalCertificateStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        personalCertificateStore.Open(OpenFlags.ReadOnly);
        X509CertificateCollection certificatesBySubjectName = personalCertificateStore.Certificates.Find(X509FindType.FindBySubjectName, expectedSubjectName, true);
        if (certificatesBySubjectName.Count == 0)
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, false);
        }
        X509Certificate2 matchingCertificate = null;
        foreach (X509Certificate2 certificateBySubjectName in certificatesBySubjectName)
        {
            if (certificateBySubjectName.Issuer == expectedIssuerName)
            {
                matchingCertificate = certificateBySubjectName;
                break;
            }
        }
        if (matchingCertificate == null)
        {
            ThrowCertificateNotFoundException(expectedSubjectName, expectedIssuerName, false);
        }
        return matchingCertificate;
    }
    private static bool VerifyCertificateIssuer(string expectedSubjectName, string expectedIssuerName, X509Certificate2 issuerCertificate)
    {
        X509Certificate2 matchingCertificate = GetCertificate(expectedSubjectName, expectedIssuerName);
        X509Chain chain = new X509Chain();
        chain.Build(matchingCertificate);
        bool x = Encoding.ASCII.GetString(chain.ChainElements[1].Certificate.RawData) == Encoding.ASCII.GetString(issuerCertificate.RawData);
        byte[] certificateData = matchingCertificate.RawData;
        MemoryStream asn1Stream = new MemoryStream(certificateData);
        BinaryReader asn1StreamReader = new BinaryReader(asn1Stream);
        // The der encoded certificate structure is like this:
        // Root Sequence
        //     Sequence (Certificate Content)
        //     Sequence (Signature Algorithm (like SHA256withRSAEncryption)
        //     Sequence (Signature)
        // We need to decode the ASN.1 content to get
        //     Sequence 0 (which is the actual certificate content that is signed by the issuer, including the sequence definition and tag number and length)
        //     Sequence 2 (which is the signature. X509Certificate2 class does not give us that information. The year is 2015)
        // Read the root sequence (ignore)
        byte leadingOctet = asn1StreamReader.ReadByte();
        ReadTagNumber(leadingOctet, asn1StreamReader);
        ReadDataLength(asn1StreamReader);
        // Save the current position because we will need it for including the sequence header with the certificate content
        int sequence0StartPosition = (int)asn1Stream.Position;
        leadingOctet = asn1StreamReader.ReadByte();
        ReadTagNumber(leadingOctet, asn1StreamReader);
        int sequence0ContentLength = ReadDataLength(asn1StreamReader);
        int sequence0HeaderLength = (int)asn1Stream.Position - sequence0StartPosition;
        sequence0ContentLength += sequence0HeaderLength;
        byte[] sequence0Content = new byte[sequence0ContentLength];
        asn1Stream.Position -= 4;
        asn1StreamReader.Read(sequence0Content, 0, sequence0ContentLength);
        // Skip sequence 1 (signature algorithm) since we don't need it and assume that we know it because we own the issuer certificate
        // This sequence, containing the algorithm used during the signing process IS HIDDEN FROM US BY DEFAULT. The year is 2015.
        // What should have been done for real is, to get the algorithm ID (hash algorithm and asymmetric algorithm) and to use those
        // algorithms during the verification process
        leadingOctet = asn1StreamReader.ReadByte();
        ReadTagNumber(leadingOctet, asn1StreamReader);
        int sequence1ContentLength = ReadDataLength(asn1StreamReader);
        byte[] sequence1Content = new byte[sequence1ContentLength];
        asn1StreamReader.Read(sequence1Content, 0, sequence1ContentLength);
        // Read sequence 2 (signature)
        // The actual signature of the certificate IS HIDDEN FROM US BY DEFAULT. The year is 2015.
        leadingOctet = asn1StreamReader.ReadByte();
        ReadTagNumber(leadingOctet, asn1StreamReader);
        int sequence2ContentLength = ReadDataLength(asn1StreamReader);
        byte unusedBits = asn1StreamReader.ReadByte();
        sequence2ContentLength -= 1;
        byte[] sequence2Content = new byte[sequence2ContentLength];
        asn1StreamReader.Read(sequence2Content, 0, sequence2ContentLength);
        // At last, we have the data that is signed and the signature.
        bool verificationResult = ((RSACryptoServiceProvider)issuerCertificate.PublicKey.Key)
        .VerifyData
        (
            sequence0Content,
            CryptoConfig.MapNameToOID("SHA256"),
            sequence2Content
        );
        return verificationResult;
    }
    private static byte[] ReadTagNumber(byte leadingOctet, BinaryReader inputStreamReader)
    {
        List<byte> byts = new List<byte>();
        byte temporaryByte;
        if ((leadingOctet & 0x1F) == 0x1F) // More than 1 byte is used to specify the tag number
        {
            while (((temporaryByte = inputStreamReader.ReadByte()) & 0x80) > 0)
            {
                byts.Add((byte)(temporaryByte & 0x7F));
            }
            byts.Add(temporaryByte);
        }
        else
        {
            byts.Add((byte)(leadingOctet & 0x1F));
        }
        return byts.ToArray();
    }
    private static int ReadDataLength(BinaryReader inputStreamReader)
    {
        byte leadingOctet = inputStreamReader.ReadByte();
        if ((leadingOctet & 0x80) > 0)
        {
            int subsequentialOctetsCount = leadingOctet & 0x7F;
            int length = 0;
            for (int i = 0; i < subsequentialOctetsCount; i++)
            {
                length <<= 8;
                length += inputStreamReader.ReadByte();
            }
            return length;
        }
        else
        {
            return leadingOctet;
        }
    }
    private static byte[] GetTagNumber(byte leadingOctet, BinaryReader inputStreamReader, ref int readBytes)
    {
        List<byte> byts = new List<byte>();
        byte temporaryByte;
        if ((leadingOctet & 0x1F) == 0x1F) // More than 1 byte is used to specify the tag number
        {
            while (((temporaryByte = inputStreamReader.ReadByte()) & 0x80) > 0)
            {
                readBytes++;
                byts.Add((byte)(temporaryByte & 0x7F));
            }
            byts.Add(temporaryByte);
        }
        else
        {
            byts.Add((byte)(leadingOctet & 0x1F));
        }
        return byts.ToArray();
    }
