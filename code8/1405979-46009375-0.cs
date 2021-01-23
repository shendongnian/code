    public class FirebaseTokenGenerator
    {
        // private_key from the Service Account JSON file
        public static string firebasePrivateKey;
    
        // Same for everyone
        public static string firebasePayloadAUD = "https://identitytoolkit.googleapis.com/google.identity.identitytoolkit.v1.IdentityToolkit";
    
        // client_email from the Service Account JSON file
        public static string firebasePayloadISS;
        public static string firebasePayloadSUB;
    
        // the token 'exp' - max 3600 seconds - see https://firebase.google.com/docs/auth/server/create-custom-tokens
        public static int firebaseTokenExpirySecs = 3600;
    
        private static RsaPrivateCrtKeyParameters _rsaParams;
        private static object _rsaParamsLocker = new object();
    
        public FirebaseTokenGenerator(string privateKey, string clientEmail)
        {
            firebasePrivateKey = privateKey ?? throw new ArgumentNullException(nameof(privateKey));
            firebasePayloadISS = clientEmail ?? throw new ArgumentNullException(nameof(clientEmail));
            firebasePayloadSUB = clientEmail;
        }
    
        public static string EncodeToken(string uid, Dictionary<string, object> claims)
        {
            // Get the RsaPrivateCrtKeyParameters if we haven't already determined them
            if (_rsaParams == null)
            {
                lock (_rsaParamsLocker)
                {
                    if (_rsaParams == null)
                    {
                        using (var stream = GenerateStreamFromString(firebasePrivateKey.Replace(@"\n", "\n")))
                        {
                            using (var sr = new StreamReader(stream))
                            {
                                var pr = new Org.BouncyCastle.OpenSsl.PemReader(sr);
                                _rsaParams = (RsaPrivateCrtKeyParameters)pr.ReadObject();
                            }
                        }
                    }
                }
            }
    
            var payload = new Dictionary<string, object> {
                {"uid", uid}
                ,{"iat", SecondsSinceEpoch(DateTime.UtcNow)}
                ,{"exp", SecondsSinceEpoch(DateTime.UtcNow.AddSeconds(firebaseTokenExpirySecs))}
                ,{"aud", firebasePayloadAUD}
                ,{"iss", firebasePayloadISS}
                ,{"sub", firebasePayloadSUB}
            };
    
            if (claims != null && claims.Any())
            {
                payload.Add("claims", claims);
            }
    
            return JWT.Encode(payload, Org.BouncyCastle.Security.DotNetUtilities.ToRSA(_rsaParams), JwsAlgorithm.RS256);
        }
    
    
        private static long SecondsSinceEpoch(DateTime dt)
        {
            TimeSpan t = dt - new DateTime(1970, 1, 1);
            return (long)t.TotalSeconds;
        }
    
        private static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
