    public partial class Startup
    {
        private static SigningCredentials CreateSigningCredentials()
        {
            var certificate = LoadCertificate();
            var key = new X509SecurityKey(certificate);
            var credentials = new SigningCredentials(key,
                SecurityAlgorithms.RsaSha256Signature,
                SecurityAlgorithms.Sha256Digest);
            return credentials;
        }
        private static X509Certificate2 LoadCertificate()
        {
            var resourceName = "ResourceOwnerPasswordFlow.Certificate.pfx";
            using (var stream = typeof(Startup)
                .GetTypeInfo()
                .Assembly
                .GetManifestResourceStream(resourceName))
            using (var buffer = new MemoryStream())
            {
                stream.CopyTo(buffer);
                buffer.Flush();
                return new X509Certificate2(
                    buffer.ToArray(),
                    "Owin.Security.OpenIdConnect.Server");
            }
        }
    }
