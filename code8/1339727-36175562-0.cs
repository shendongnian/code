    public static string Decode(string token, string key, bool verify = true)
            {
                string[] parts = token.Split('.');
                string header = parts[0];
                string payload = parts[1];
                byte[] crypto = Base64UrlDecode(parts[2]);
    
                string headerJson = Encoding.UTF8.GetString(Base64UrlDecode(header));
                JObject headerData = JObject.Parse(headerJson);
    
                string payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
                JObject payloadData = JObject.Parse(payloadJson);
    
                if (verify)
                {
                    var keyBytes = Convert.FromBase64String(key); // your key here
    
                    AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
                    RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
                    RSAParameters rsaParameters = new RSAParameters();
                    rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
                    rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.ImportParameters(rsaParameters);
    
                    SHA256 sha256 = SHA256.Create();
                    byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(parts[0] + '.' + parts[1]));
    
                    RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                    rsaDeformatter.SetHashAlgorithm("SHA256");
                    if (!rsaDeformatter.VerifySignature(hash, FromBase64Url(parts[2])))
                        throw new ApplicationException(string.Format("Invalid signature"));
                }
    
                return payloadData.ToString();
            }
