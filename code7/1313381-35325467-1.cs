    var response = new Saml2Response(
                new EntityId(systemAUrl),
                CertificateHelper.SigningCertificate,
                new Uri(AssertionConsumerServiceUrl),
                null, null, claimsIdentity);
    var bindingResult = Saml2Binding.Get(model.AssertionModel.ResponseBinding).Bind(response)
    // If this is an MVC action you can convert the bindingResult to
    // an ActionResult using the ToActionResult() extension from the
    // Kentor.AuthServices.Mvc package.
    return bindingResult.ToActionResult();
    // If you're using web forms, you can use the Apply() extension
    // method from the Kentor.AuthServices.HttpModule package. Apply
    // calls Response.End() internally.
    bindingResult.Apply(new HttpResponseWrapper(HttpContext.Current.Response));
