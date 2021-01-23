    public static Dictionary<string, Dictionary<string, string>> getSettings(string settingsStr)
    {
        return settingsStr.Split('|').ToDictionary(
            template => template.Split('_')[0],
            template => template.Split('_')[1].Split(',').ToDictionary(
                setting => setting.Split('=')[0],
                setting => setting.Split('=')[1]));
    }
