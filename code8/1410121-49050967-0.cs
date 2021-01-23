    using Microsoft.AspNetCore.DataProtection;
    
    // During startup add DP
    serviceCollection.AddDataProtection();
    
    ...
    
    // the 'provider' parameter is provided by DI
    public MyClass(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("Contoso.MyClass.v1");
    }
    
    ...
    
    // protect the payload
    string protectedPayload = _protector.Protect(input);
    Console.WriteLine($"Protect returned: {protectedPayload}");
    ...
    
    // unprotect the payload
    string unprotectedPayload = _protector.Unprotect(protectedPayload);
    Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
