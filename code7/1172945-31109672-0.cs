    EPMembershipProvider myProvider = new EPMembershipProvider();
    string configPath = "~/web.config";
    Configuration config =     WebConfigurationManager.OpenWebConfiguration(configPath);
    MembershipSection section = (MembershipSection)config.GetSection("system.web/membership");
    ProviderSettingsCollection settings = section.Providers;
    NameValueCollection membershipParams = settings[section.DefaultProvider].Parameters;
    myProvider.Initialize("EPMembershipProvider", membershipParams);
    bool Status = myProvider.ValidateUser(UserName, Password);
