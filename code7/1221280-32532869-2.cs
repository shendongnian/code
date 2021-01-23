    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using Org.BouncyCastle.Asn1;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] data = Convert.FromBase64String("dGF0b0Bmcm9td2luMzIuY29t");
                byte[] signature = Convert.FromBase64String("lWKRRgWBA2lBAfUvBS+54s9kmHTH3nJwcvYYmjCg5QpWQ9joY7Rzpq0zZjOhyxASXoAN4Vz8+mqSqPWi/4DFH7947ZWZSbopPfxiI7jjDRMAVymG0B+dRVjiMow48ZvhgP/FGSZqeLAei77Z0aAmwN2TBxkClqBpt9uy+nkI7V/TJGAbbLcWfiPWNVOGsU0smoFDQLlJjkocahNSOqjj+9PPFVqbc/VVHQWsSoq1ZxtCPILFwPCCtUCDITXrU/riGMFJ282p/3rfhDJKYis9/izR98/zgBLRoCew8zu8Za4UNWaHaR3HP/6voQI2NiVSKtss1VjvwjwXYIOh56yeSw==");
                byte[] publicKey = Convert.FromBase64String("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAp6HzbSgZPkJPfZJWydFAKdzUWlQcGHCTZhghg8HwHOfRZp3QZ/iiDORVzdIlW6XYPz76aAn8Nxm/v4NbsQsFPbwIcc7CPOJe21VT+7f6ocZ4kef0dqxUOGuK1FynrqzsAeYoaeTW+w/HElXODOEzZs3CfyE3d4hy3TTM/mVyQGV1FO/hHWB/zXq7ryQ8hXP/ueJimmJvitB7UweemRxvEYfVx52VVAgzg1RqVWeRj8L/obfm0lwQtIAHdDOnIi/cwpsyKQNikjMsf4dFgt14fcOgFdSG06jB840GnOsRZM04CWZQ9ttwAvoNGK/zjriRYGySQ4Ey0K0l5G3UVr56mQIDAQAB");
                
                byte[] hash;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hash = sha256.ComputeHash(data);
                }
    
                bool b = false;
                var rsaParam = GetPublicKeyRSAParameters(publicKey);
    
                using (var rsa = new RSACryptoServiceProvider())
                {
                    // Import public key
                    rsa.ImportParameters(rsaParam);
    
                    // Create signature verifier with the rsa key
                    var signatureDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
    
                    // Set the hash algorithm to SHA256.
                    signatureDeformatter.SetHashAlgorithm("SHA256");
    
                    b = signatureDeformatter.VerifySignature(hash, signature);
                } 
            }
    
            public static RSAParameters GetPublicKeyRSAParameters(byte[] subjectPublicKeyInfoBytes)
            {
                var publicKeyObject = (DerSequence)Asn1Object.FromByteArray(subjectPublicKeyInfoBytes);
                var rsaPublicKeyParametersBitString = (DerBitString)publicKeyObject[1];
    
                var rsaPublicKeyParametersObject = (DerSequence)Asn1Object.FromByteArray(rsaPublicKeyParametersBitString.GetBytes());
    
                var modulus = ((DerInteger)rsaPublicKeyParametersObject[0]).Value.ToByteArray().Skip(1).ToArray();
                var exponent = ((DerInteger)rsaPublicKeyParametersObject[1]).Value.ToByteArray();
    
                return new RSAParameters() { Modulus = modulus, Exponent = exponent };
            }
        }
    }
