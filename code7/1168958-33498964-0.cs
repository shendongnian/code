    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.OpenSsl;
    
    namespace hsynlms.Classes
    {
        public class Cryptography
        {
            public string GetSHA1withRSAKey(string pemTxtFilePath, string sData)
            {
                try
                {
                    if (!File.Exists(pemTxtFilePath))
                    {
                        throw new Exception("PEM (txt) file not found.");
                    }
    
                    using (var reader = File.OpenText(pemTxtFilePath))
                    {
                        var pemReader = new PemReader(reader);
                        var bouncyRsaParameters = (RsaPrivateCrtKeyParameters)pemReader.ReadObject();
    
                        var rsaParameters = new RSAParameters();
                        rsaParameters.Modulus = bouncyRsaParameters.Modulus.ToByteArrayUnsigned();
                        rsaParameters.P = bouncyRsaParameters.P.ToByteArrayUnsigned();
                        rsaParameters.Q = bouncyRsaParameters.Q.ToByteArrayUnsigned();
                        rsaParameters.DP = bouncyRsaParameters.DP.ToByteArrayUnsigned();
                        rsaParameters.DQ = bouncyRsaParameters.DQ.ToByteArrayUnsigned();
                        rsaParameters.InverseQ = bouncyRsaParameters.QInv.ToByteArrayUnsigned();
                        rsaParameters.D = bouncyRsaParameters.Exponent.ToByteArrayUnsigned();
                        rsaParameters.Exponent = bouncyRsaParameters.PublicExponent.ToByteArrayUnsigned();
    
                        var privateKey = new RSACryptoServiceProvider();
                        privateKey.ImportParameters(rsaParameters);
    
                        var sha = new SHA1Managed();
    
                        UTF8Encoding str = new UTF8Encoding(true);
                        byte[] signedData = privateKey.SignData(str.GetBytes(sData), sha);
                        var result = Convert.ToBase64String(signedData);
    
                        return result;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Signing SHA1 with RSA failed.");
                }
            }
        }
    }
