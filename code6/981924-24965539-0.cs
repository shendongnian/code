    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace RsaDotNetToJava
    {
    	class MainClass
    	{
    		public byte[] RSAEncrypt(byte[] data, RSAParameters param, bool padding) {
    			using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(1024)) {
    				rsaProvider.ImportParameters(param);
    
    				var encryptedData = rsaProvider.Encrypt(data, false);
    
    				return encryptedData;
    			}
    		}
    
    		public static void W(string label, byte [] x) {
    			var b64 = Convert.ToBase64String (x);
    			Console.WriteLine ("{0} = {1}", label, b64);
    		}
    
    		public static void Main (string[] args)
    		{
    			var x = new MainClass ();
    			var rsa = new RSACryptoServiceProvider (1024);
    			var data = Encoding.ASCII.GetBytes("Hello world");
    			var parms = rsa.ExportParameters(true);
    			W ("Modulus", parms.Modulus);
    			W ("P", parms.P);
    			W ("DecryptExponent", parms.D);
    			W ("EncryptExponent", parms.Exponent);
    			var cipher = x.RSAEncrypt(data, parms, false);
    			W ("Cipher", cipher);
    		}
    	}
    }
