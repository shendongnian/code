    public partial class Startup
    {
        private static X509Certificate2 LoadCertificate()
        {
            using (var stream = typeof(Startup)
                .GetTypeInfo()
                .Assembly
                .GetManifestResourceStream("ResourceOwnerPasswordFlow.Certificate.pfx"))
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
