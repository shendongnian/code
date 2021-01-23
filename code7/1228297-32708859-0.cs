    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    // there should go namespace and class definition
    ...
    //
    public bool KeyUsageHasUsage(X509Certificate2 cert, X509KeyUsageFlags flag) {
		if (cert.Version < 3) { return true; }
		List<X509KeyUsageExtension> extensions = cert.Extensions.OfType<X509KeyUsageExtension>().ToList();
		if (!extensions.Any()) {
			return flag != X509KeyUsageFlags.CrlSign && flag != X509KeyUsageFlags.KeyCertSign;
		}
		return (extensions[0].KeyUsages & flag) > 0;
	}
