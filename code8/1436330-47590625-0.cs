    public class CustomCredentials : ClientCredentials
    {
        public CustomCredentials()
        { }
        protected CustomCredentials(CustomCredentials cc)
            : base(cc)
        { }
        public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CustomSecurityTokenManager(this);
        }
        protected override ClientCredentials CloneCore()
        {
            return new CustomCredentials(this);
        }
    }
    public class CustomSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        public CustomSecurityTokenManager(CustomCredentials cred)
            : base(cred)
        { }
        public override System.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(System.IdentityModel.Selectors.SecurityTokenVersion version)
        {
            return new CustomTokenSerializer(System.ServiceModel.Security.SecurityVersion.WSSecurity11);
        }
    }
    public class CustomTokenSerializer : WSSecurityTokenSerializer
    {
        public CustomTokenSerializer(SecurityVersion sv)
            : base(sv)
        { }
        protected override void WriteTokenCore(System.Xml.XmlWriter writer, System.IdentityModel.Tokens.SecurityToken token)
        {
            UserNameSecurityToken userToken = token as UserNameSecurityToken;
            string tokennamespace = "o";
            DateTime created = DateTime.UtcNow;
            string createdStr = created.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
                        
            Random r = new Random();
            var nonce = Convert.ToBase64String(Encoding.ASCII.GetBytes(GetSHA1String(created + r.Next().ToString())));
           // string password = GetSHA1String(nonce + createdStr + userToken.Password);
            writer.WriteRaw(string.Format(
            "<{0}:UsernameToken u:Id=\"" + "UsernameToken-ABCD" +
            "\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
            "<{0}:Username>" + userToken.UserName + "</{0}:Username>" +
            "<{0}:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" +
            userToken.Password + "</{0}:Password>" +
            "<{0}:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" +
            nonce + "</{0}:Nonce>" +
            "<u:Created>" + createdStr + "</u:Created></{0}:UsernameToken>", tokennamespace));
        }
        protected string GetSHA1String(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] hashedDataBytes = sha1Hasher.ComputeHash(encoder.GetBytes(phrase));
            return ByteArrayToString(hashedDataBytes);
        }
        protected String ByteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
     public static YOURContractClient CreateRealTimeOnlineProxy(string url, string username, string password)
        {
            CustomBinding binding = new CustomBinding();
            var security = TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement();
            security.IncludeTimestamp = false;
            security.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256;
            security.AllowInsecureTransport = true;
            security.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            var encoding = new TextMessageEncodingBindingElement();
            encoding.MessageVersion = MessageVersion.Soap11;
            var transport = new HttpTransportBindingElement();
            transport.MaxReceivedMessageSize = 20000000; // 20 megs
            binding.Elements.Add(security);
            binding.Elements.Add(encoding);
            binding.Elements.Add(transport);
            YOURContractClient client = new YOURContractClient(binding, new EndpointAddress(url));
            client.ChannelFactory.Endpoint.Behaviors.Remove<System.ServiceModel.Description.ClientCredentials>();
            client.ChannelFactory.Endpoint.Behaviors.Add(new CustomCredentials());
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }
