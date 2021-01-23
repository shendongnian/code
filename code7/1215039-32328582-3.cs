    Asn1Object asn = asn1Object(File.ReadAllBytes(@"test_file.cat"));
    Asn1Object value = FindAsn1Value("1.3.6.1.4.1.311.12.2.1", asn);
    if (value is DerOctetString)
    {
        UnicodeEncoding unicode = new UnicodeEncoding(true, true);
        Console.WriteLine("DerOctetString = {0}", unicode.GetString(((DerOctetString)value).GetOctets()));
    }
