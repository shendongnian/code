	[RoutePrefix("api/certificatetest")]
    public class CertificateTestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var handler = new WebRequestHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ClientCertificates.Add(GetClientCert());
            handler.UseProxy = false;
            var client = new HttpClient(handler);
            var result = client.GetAsync("https://localhost:44331/api/values").GetAwaiter().GetResult();
            var resultString = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return Ok(resultString);
        }
        private static X509Certificate GetClientCert()
        {
            X509Store store = null;
            try
            {
                store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                var certificateSerialNumber= "‎81 c6 62 0a 73 c7 b1 aa 41 06 a3 ce 62 83 ae 25".ToUpper().Replace(" ", string.Empty);
                //Does not work for some reason, could be culture related
                //var certs = store.Certificates.Find(X509FindType.FindBySerialNumber, certificateSerialNumber, true);
                //if (certs.Count == 1)
                //{
                //    var cert = certs[0];
                //    return cert;
                //}
                var cert = store.Certificates.Cast<X509Certificate>().FirstOrDefault(x => x.GetSerialNumberString().Equals(certificateSerialNumber, StringComparison.InvariantCultureIgnoreCase));
                return cert;
            }
            finally
            {
                store?.Close();
            }
        }
    }
