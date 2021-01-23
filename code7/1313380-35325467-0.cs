    var response = new Saml2Response(
                new EntityId(systemAUrl),
                CertificateHelper.SigningCertificate,
                new Uri(AssertionConsumerServiceUrl),
                null, null, claimsIdentity);
    
    // Assuming this is in an MVC action you can use ToActionResult()
    // from the Kentor.AuthServices.Mvc package. There's also a method
    // that lets you apply the result directly to the HttpContext in
    // the Kentor.AuthServices.HttpModule package.
    return Saml2Binding.Get(model.AssertionModel.ResponseBinding)
                    .Bind(response).ToActionResult();
