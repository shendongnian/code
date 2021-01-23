    private const string DisableCachingName = @"TestSwitch.LocalAppContext.DisableCaching";
    private const string DontEnableSchUseStrongCryptoName = @"Switch.System.Net.DontEnableSchUseStrongCrypto";
    static void Main(string[] args)
    {
        AppContext.SetSwitch(DisableCachingName, true);
        AppContext.SetSwitch(DontEnableSchUseStrongCryptoName, false);
