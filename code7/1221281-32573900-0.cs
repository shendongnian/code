    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var verified = false;
    
                byte[] data = Convert.FromBase64String("dGF0b0Bmcm9td2luMzIuY29t");
                byte[] signature = Convert.FromBase64String("lWKRRgWBA2lBAfUvBS+54s9kmHTH3nJwcvYYmjCg5QpWQ9joY7Rzpq0zZjOhyxASXoAN4Vz8+mqSqPWi/4DFH7947ZWZSbopPfxiI7jjDRMAVymG0B+dRVjiMow48ZvhgP/FGSZqeLAei77Z0aAmwN2TBxkClqBpt9uy+nkI7V/TJGAbbLcWfiPWNVOGsU0smoFDQLlJjkocahNSOqjj+9PPFVqbc/VVHQWsSoq1ZxtCPILFwPCCtUCDITXrU/riGMFJ282p/3rfhDJKYis9/izR98/zgBLRoCew8zu8Za4UNWaHaR3HP/6voQI2NiVSKtss1VjvwjwXYIOh56yeSw==");
                byte[] publicKey = Convert.FromBase64String("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAp6HzbSgZPkJPfZJWydFAKdzUWlQcGHCTZhghg8HwHOfRZp3QZ/iiDORVzdIlW6XYPz76aAn8Nxm/v4NbsQsFPbwIcc7CPOJe21VT+7f6ocZ4kef0dqxUOGuK1FynrqzsAeYoaeTW+w/HElXODOEzZs3CfyE3d4hy3TTM/mVyQGV1FO/hHWB/zXq7ryQ8hXP/ueJimmJvitB7UweemRxvEYfVx52VVAgzg1RqVWeRj8L/obfm0lwQtIAHdDOnIi/cwpsyKQNikjMsf4dFgt14fcOgFdSG06jB840GnOsRZM04CWZQ9ttwAvoNGK/zjriRYGySQ4Ey0K0l5G3UVr56mQIDAQAB");
    
                byte[] modulus;
                byte[] exponent;
                ExtractPublicKeyParameters(publicKey, out modulus, out exponent);
    
                using (var rsa = new RSACryptoServiceProvider())
                {
                    // Create parameters
                    var rsaParam = new RSAParameters()
                    {
                        Modulus = modulus,
                        Exponent = exponent
                    };
    
                    // Import public key
                    rsa.ImportParameters(rsaParam);
    
                    // Create signature verifier with the rsa key
                    var signatureDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
    
                    // Set the hash algorithm to SHA256.
                    signatureDeformatter.SetHashAlgorithm("SHA256");
    
                    // Compute hash
                    byte[] hash;
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        hash = sha256.ComputeHash(data);
                    }
    
                    verified = signatureDeformatter.VerifySignature(hash, signature);
                } 
    
            }
    
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            static readonly byte[] SeqOid = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
    
            public static void ExtractPublicKeyParameters(byte[] publicKey, out byte[] modulus, out byte[] exponent)
            {
                modulus = new byte[0];
                exponent = new byte[0];
    
                byte[] seq = new byte[15];
    
                // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
                MemoryStream mem = new MemoryStream(publicKey);
                BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
                byte bt = 0;
                ushort twobytes = 0;
    
                try
                {
    
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return;
    
                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, SeqOid))    //make sure Sequence for OID is correct
                        return;
    
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return;
    
                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return;
    
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return;
    
                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;
    
                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);
    
                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }
    
                    modulus = binr.ReadBytes(modsize);   //read the modulus bytes
    
                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    exponent = binr.ReadBytes(expbytes);
                }
    
                finally
                {
                    binr.Close();
                }
            }
    
            private static bool CompareBytearrays(byte[] a, byte[] b)
            {
                if (a.Length != b.Length)
                    return false;
                int i = 0;
                foreach (byte c in a)
                {
                    if (c != b[i])
                        return false;
                    i++;
                }
                return true;
            }
        }
    }
