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
                const string pubkey = @"...";
                const string prikey = @"...";
    
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
