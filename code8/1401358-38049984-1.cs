    public override ICapabilities ToCapabilities()
    {
      Dictionary<string, object> dictionary = this.BuildChromeOptionsDictionary();
      DesiredCapabilities desiredCapabilities = DesiredCapabilities.Chrome();
      desiredCapabilities.SetCapability(ChromeOptions.Capability, (object) dictionary);
      if (this.proxy != null)
        desiredCapabilities.SetCapability(CapabilityType.Proxy, (object) this.proxy);
      Dictionary<string, object> preferencesDictionary = this.GenerateLoggingPreferencesDictionary();
      if (preferencesDictionary != null)
        desiredCapabilities.SetCapability(CapabilityType.LoggingPreferences, (object) preferencesDictionary);
      foreach (KeyValuePair<string, object> additionalCapability in this.additionalCapabilities)
        desiredCapabilities.SetCapability(additionalCapability.Key, additionalCapability.Value);
      
