    [global::System.Configuration.ApplicationScopedSettingAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Configuration.DefaultSettingValueAttribute("This is my default string value")] // << This is what you are looking for
    public string TestSetting
    {
      get
      {
        return ((string)(this["TestSetting"]));
      }
    }
    [global::System.Configuration.UserScopedSettingAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Configuration.DefaultSettingValueAttribute("False")]  // << This is what you are looking for
    public bool AnotherSetting
    {
      get
      {
        return ((bool)(this["AnotherSetting"]));
      }
      set
      {
        this["AnotherSetting"] = value;
      }
    }
