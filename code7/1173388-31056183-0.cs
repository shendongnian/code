    // Create a new domain with the dynamic assembly.
    var domain = AppDomain.Create("Dynamic Assembly Domain");
    domain.Load("mydll.dll");
    // Do some work with the dynamic domain...
    // Unload the domain.
    AppDomain.Unload(domain);
