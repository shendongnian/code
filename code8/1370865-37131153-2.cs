    using System;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Asn1.Pkcs;
    using Org.BouncyCastle.Asn1;
    
    namespace EncryptTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string pubkey = @"MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAuQhcZKNnIC2bvJhI5Yzq
    oH9uGAHuiAt9bOXdIrsaeEwsIUMuyNfXkLozwlcJb0YLgqhpP3gNLb58WCb1AvkV
    ZHgzLQbay93HwmBiEPW6LZIKGsHwh1awBmJpeWhU8h3oNP+KpNq44H+jAeM9G9En
    W0y7+AUbe3pnisOWVZHmM72A2mLq1piCOjmvjegzgB8/rU7ZkRrNadeFO7DBP0Ew
    6eElS3iXfFHJmbK+L5lL0pFxvUMRfGVC33NQkuSoWiQJZsYyUgIk6WSOQm3t5fw6
    VESMTfd1xKlaBGp7IrWksthEF+XAu5ziAcSdjBwJLEFzJ2830cQ4GhFS3JtU/Iao
    6MbJkUuaHoI3Xx9C7d6RiKbK1uZrOHjyVsUhqpYwyAUdrViraj0pybxbE2GwbRC4
    /NyHuPKG3gBULiGYbl8wwlhl71nRVdkPQtGw36kmGWHRk3ERM6JgLWsDZjED4ak2
    Na6VzIvnqVs0HROl/4Rd4rHZvl9t39tfVBtofEkD4C0B5BdgW/B2XQM7Fd4celn3
    q/+FKmvaVydoFGG0s4YZL6hsqOISfhdT10jGrwNKe+zupnrXZO66mtX8rvPtY4x2
    WXcHrbp1cgSr+2r8Mteh8Eff+6rqArU1i1ezDm3SrKs1WMFKu1hRKDYudfOaB/L7
    gvEvD+lUE9qnjlYUBGSXKMUCAwEAAQ==";
                const string prikey = @"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";
    
                var publickey = Convert.FromBase64String(pubkey);
                var privatekey = Convert.FromBase64String(prikey);
    
                var asnprivate = Asn1Object.FromStream(new MemoryStream(privatekey));
                var privStruct = new RsaPrivateKeyStructure((Asn1Sequence)asnprivate);
    
                RsaKeyParameters privateAsymmetricKey = new RsaKeyParameters(true, privStruct.Modulus, privStruct.PrivateExponent);
                RsaKeyParameters publicAsymmetricKey = (RsaKeyParameters)PublicKeyFactory.CreateKey(publickey);
    
                var inputBytes = Encoding.UTF8.GetBytes("the message");
    
                Console.WriteLine("--- Message: ----");
                Console.WriteLine(Encoding.UTF8.GetString(inputBytes));
    
                IAsymmetricBlockCipher cipher = new RsaEngine();
                cipher.Init(true, publicAsymmetricKey);
                var cipheredBytes = cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
    
                Console.WriteLine("--- Enc utf8: ----");
                Console.WriteLine(Encoding.UTF8.GetString(cipheredBytes));
    
                Console.WriteLine("--- Enc Base64: ----");
                Console.WriteLine(Convert.ToBase64String(cipheredBytes));
    
                cipher.Init(false, privateAsymmetricKey);
                var deciphered = cipher.ProcessBlock(cipheredBytes, 0, cipheredBytes.Length);
    
                Console.WriteLine("--- Dec: ----");
                Console.WriteLine(Encoding.UTF8.GetString(deciphered));
                Console.ReadLine();
            }
        }
    }
