    public static string getSettingsStr(Dictionary<string, Dictionary<string, string>> settings)
    {
        return string.Join("|",
            settings.Select(kvp =>
                kvp.Key + "_" + string.Join(",",
                    kvp.Value.Select(setting =>
                        setting.Key + "=" + setting.Value))));
    }
