    private string EncodeToken(string uid, Dictionary<string, object> claims)
        {
            string jwt = string.Empty;
            RsaPrivateCrtKeyParameters _rsaParams;
            using (StreamReader sr = new StreamReader(GenerateStreamFromString(private_key.Replace(@"\n", "\n"))))
            {
                var pr = new Org.BouncyCastle.OpenSsl.PemReader(sr);
                _rsaParams = (RsaPrivateCrtKeyParameters)pr.ReadObject();
            }
            
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                Dictionary<string, object> payload = new Dictionary<string, object> {
                    {"claims", claims}
                    ,{"uid", uid}
                    ,{"iat", secondsSinceEpoch(DateTime.UtcNow)}
                    ,{"exp", secondsSinceEpoch(DateTime.UtcNow.AddSeconds(firebaseTokenExpirySecs))}
                    ,{"aud", firebasePayloadAUD}
                    ,{"iss", client_email}
                    ,{"sub", client_email}
                };
                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(_rsaParams);
                rsa.ImportParameters(rsaParams);
                jwt = JWT.Encode(payload, rsa, Jose.JwsAlgorithm.RS256);
            }
            return jwt;
        }
