    string section1Key1 = SettingsProvider.GetValue("Section1", "Key1", "default");
    SettingsProvider.SetValue("Section1", "Key1", "OtherValue");
    SettingsProvider.SetValue("Section1", "Key2", "Value2");
    SettingsProvider.SetValue("Section2", "Key1", "Value3");
    SettingsProvider.RemoveSetting("Section2", "Key1");
    SettingsProvider.RemoveSetting("Section1", "Key2");
