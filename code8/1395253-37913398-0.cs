    services.AddDataProtection()
        .SetApplicationName("myweb")
        .ProtectKeysWithCertificate("thumbprint");
    
    services.AddSingleton<IXmlRepository, CustomDataProtectionRepository>();
