    public class XYZSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        static readonly object syncRoot = new object();
        static string stsKey = "XYZSecurityTokenServiceConfiguration";
        public static XYZSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;
                XYZSecurityTokenServiceConfiguration myConfiguration = httpAppState.Get(stsKey) as XYZSecurityTokenServiceConfiguration;
                if (myConfiguration != null)
                {
                    return myConfiguration;
                }
                lock (syncRoot)
                {
                    myConfiguration = httpAppState.Get(stsKey) as XYZSecurityTokenServiceConfiguration;
                    if (myConfiguration == null)
                    {
                        myConfiguration = new XYZSecurityTokenServiceConfiguration();
                        httpAppState.Add(stsKey, myConfiguration);
                    }
                    return myConfiguration;
                }
            }
        }
        public XYZSecurityTokenServiceConfiguration() : base("XYZPassiveSTS", CertificateUtil.SigningCreds)
        {
            this.SecurityTokenService = typeof(TLCSecurityTokenService);
        }
    }
    public class XYZSecurityTokenService : SecurityTokenService
    {
        public XYZSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {                        
        }
        void ValidateAppliesTo(EndpointReference appliesTo)
        {
            if (appliesTo == null)
            {
                throw new ArgumentNullException("appliesTo");
            }
        }
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            ValidateAppliesTo(request.AppliesTo);
            Scope scope = new Scope(
                request.AppliesTo.Uri.OriginalString,
                SecurityTokenServiceConfiguration.SigningCredentials);
            scope.TokenEncryptionRequired = false;
            scope.ReplyToAddress = scope.AppliesToAddress;
            //scope.ReplyToAddress = request.ReplyTo;
            return scope;
        }
        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            //We Can Add Additonal Claims Here!
            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaims(principal.Claims);
            string userName = principal.Identity.Name;
            //Use EF To get user's roles by userName,
            var roles = DBContext.GetRolesForUser(userName);
            foreach (var role in roles)
            {
               Claim roleClaim = new Claim(ClaimTypes.Role, role.Role, ClaimValueTypes.String);
               claims.AddClaims(roleClaim);
            }
        }
    }
    public class CertificateUtil
    {
        #region Fields
        private const string SIGNING_CERTIFICATE_NAME = "CN=TokenSigningCert";
        private const string ENCRYPTING_CERTIFICATE_NAME = "CN=TokenSigningCert";
        private static SigningCredentials _signingCreds = null;
        private static EncryptingCredentials _encryptingCreds = null;
        #endregion
        #region Properties
        public static SigningCredentials SigningCreds
        {
            get
            {
                if (_signingCreds == null)
                    _signingCreds = new X509SigningCredentials(CertificateUtil.GetCertificate(StoreName.TrustedPeople, StoreLocation.LocalMachine, SIGNING_CERTIFICATE_NAME));
                return _signingCreds;
            }
        }
        public static EncryptingCredentials EncryptingCreds
        {
            get
            {
                if (_encryptingCreds == null)
                    _encryptingCreds = new X509EncryptingCredentials(CertificateUtil.GetCertificate(StoreName.TrustedPeople, StoreLocation.LocalMachine, ENCRYPTING_CERTIFICATE_NAME));
                return _encryptingCreds;
            }
        }
        #endregion
        /// <summary>
        /// Get the certificate from a specific store/location/subject.
        /// </summary>
        private static X509Certificate2 GetCertificate(StoreName name, StoreLocation location, string subjectName)
        {
            X509Store store = new X509Store(name, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);
            try
            {
                X509Certificate2 result = null;
                //
                // Every time we call store.Certificates property, a new collection will be returned.
                //
                certificates = store.Certificates;
                for (int i = 0; i < certificates.Count; i++)
                {
                    X509Certificate2 cert = certificates[i];
                    if (cert.SubjectName.Name.ToLower() == subjectName.ToLower())
                    {
                        if (result != null)
                        {
                            throw new ApplicationException(string.Format("More than one certificate was found for subject Name {0}", subjectName));
                        }
                        result = new X509Certificate2(cert);
                    }
                }
                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for subject Name {0}", subjectName));
                }
                return result;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }
                store.Close();
            }
        }
    }
