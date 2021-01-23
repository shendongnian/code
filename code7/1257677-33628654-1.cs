	// Read CA certificate from file.
	var now = DateTime.UtcNow;
	var certificateAuthority = new X509Certificate(_ServerCertificateLocation);
	var caEffectiveDate = DateTime.Parse(certificateAuthority.GetEffectiveDateString());
	var caExpirationDate = DateTime.Parse(certificateAuthority.GetExpirationDateString());
	// Check if CA certificate is valid.
	if (now <= caEffectiveDate
		|| now > caExpirationDate)
		return false;
	// Check if CA certificate is available in the chain.
	return chain.ChainElements.Cast<X509ChainElement>()
							  .Select(element => element.Certificate)
							  .Where(chainCertificate => chainCertificate.Subject == certificateAuthority.Subject)
							  .Where(chainCertificate => chainCertificate.GetRawCertData().SequenceEqual(certificateAuthority.GetRawCertData()))
							  .Any();
