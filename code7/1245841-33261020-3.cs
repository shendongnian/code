    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Security;
    using System.Xml;
    using Microsoft.IdentityModel.Protocols.WSTrust;
    using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;
    
    namespace ADFSFederationToken
    {
        class Program
        {
    
            static string _relyingPartyIdentifier = "https://yourapplication.local/"; // Must be whatever you specified on your AD FS server as the relying party address.
            static string _adfsServerAddress = "https://adfs.example.local/"; // Your ADFS server's address.
            static string _username = "username@domain.local"; // A username to your ADFS server.
            static string _password = "password"; // A password to your ADFS server.
            static string _signingCertificateThumbprint = "1337..."; // Put the public ADFS Token Signing Certificate's thumbprint here and be sure to add it to your application's trusted certificates in the Certificates snap-in of MMC.
            static string _signingCertificateCommonName = "ADFS Signing - adfs.example.local"; // Put the common name of the ADFS Token Signing Certificate here.
    
            static void Main(string[] args)
            {
                Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory factory = null;
                try
                {
                    _relyingPartyIdentifier = _relyingPartyIdentifier.EndsWith("/") ? _relyingPartyIdentifier : _relyingPartyIdentifier + "/";
                    _adfsServerAddress = _adfsServerAddress.EndsWith("/") ? _adfsServerAddress : _adfsServerAddress + "/";
                    factory = new Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory(new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential), new EndpointAddress(_adfsServerAddress + "adfs/services/trust/13/usernamemixed"));
                    factory.TrustVersion = TrustVersion.WSTrust13;
                    factory.Credentials.UserName.UserName = _username;
                    factory.Credentials.UserName.Password = _password;
                    var rst = new Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken
                    {
                        RequestType = WSTrust13Constants.RequestTypes.Issue,
                        AppliesTo = new EndpointAddress(_relyingPartyIdentifier),
                        KeyType = WSTrust13Constants.KeyTypes.Bearer
                    };
                    var channel = factory.CreateChannel();
                    var genericToken = channel.Issue(rst) as GenericXmlSecurityToken;
                    var handler = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
                    var tokenString = genericToken.TokenXml.OuterXml;
                    var samlToken = handler.ReadToken(new XmlTextReader(new StringReader(tokenString)));
                    ValidateSamlToken(samlToken);
                }
                finally
                {
                    if (factory != null)
                    {
                        try
                        {
                            factory.Close();
                        }
                        catch (CommunicationObjectFaultedException)
                        {
                            factory.Abort();
                        }
                    }
                }
            }
    
            public static ClaimsIdentity ValidateSamlToken(SecurityToken securityToken)
            {
                var configuration = new SecurityTokenHandlerConfiguration();
                configuration.AudienceRestriction.AudienceMode = AudienceUriMode.Always;
                configuration.AudienceRestriction.AllowedAudienceUris.Add(new Uri(_relyingPartyIdentifier));
                configuration.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
                configuration.RevocationMode = X509RevocationMode.Online;
                configuration.CertificateValidator = X509CertificateValidator.ChainTrust;
                var registry = new ConfigurationBasedIssuerNameRegistry();
                registry.AddTrustedIssuer(_signingCertificateThumbprint, _signingCertificateCommonName);
                configuration.IssuerNameRegistry = registry;
                var handler = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection(configuration);
                var identity = handler.ValidateToken(securityToken).First();
                return identity;
            }
        }
    }
