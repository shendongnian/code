           // Subject Alternative Name 
            var alternativeNames = subjectAlternativeNames.Select(n => new GeneralName(GeneralName.DnsName, n)).ToArray<Asn1Encodable>();
            var subjectAlternativeNamesExtension = new DerSequence(alternativeNames);
            certificateGenerator.AddExtension(X509Extensions.SubjectAlternativeName.Id, false, subjectAlternativeNamesExtension);
            //Key Usage
            certificateGenerator.AddExtension(X509Extensions.KeyUsage, true, new KeyUsage(KeyUsage.DigitalSignature | KeyUsage.KeyEncipherment));
