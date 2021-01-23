    using System.IO;
    using Org.BouncyCastle.Crypto.Encodings;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.X509;
    internal class Example
    {
        internal static string Decode(string data)
        {
            try
            {
                X509Certificate k;
                // read in the certificate
                using (var textReader = File.OpenText("public.cer"))
                {
                    // I'm assuming here that the certificate is PEM-encoded.
                    var pemReader = new PemReader(textReader);
                    k = (X509Certificate)pemReader.ReadObject();
                }
                // un-base64 the input
                var dataBytes = Convert.FromBase64String(data);
                // what php openssl_public_decrypt does
                var cipher = new OaepEncoding(new RsaEngine());
                cipher.Init(false, k.GetPublicKey());
                var returnBytes = cipher.ProcessBlock(dataBytes, 0, dataBytes.Length);
                // What is the character-encoding of the bytes? UTF-8?
                return Encoding.UTF8.GetString(returnBytes);
            }
            catch (Exception ex)
            {
                return "Failed:" + ex.Message;
            }
        }
    }
