    using (var fs = new FileStream("key.json", FileMode.Open, FileAccess.Read))
    {
        var credentialParameters =
            NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(fs);
        if (credentialParameters.Type != "service_account" 
            || string.IsNullOrEmpty(credentialParameters.ClientEmail) 
            || string.IsNullOrEmpty(credentialParameters.PrivateKey))
                throw new InvalidOperationException("JSON data does not represent a valid service account credential.");
        return new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer(credentialParameters.ClientEmail)
            {
                Scopes = Scopes,
                User = _adminUser //the user to be impersonated
            }.FromPrivateKey(credentialParameters.PrivateKey));
    }
