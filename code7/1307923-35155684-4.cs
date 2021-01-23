    public static string GetEnglishString(string swiss)
    {
        Type englishResources = typeof(en_US.Resources);
        Type swissResources = typeof(de_CH.Resources);
        PropertyInfo[] infos = swissResources.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
        foreach (PropertyInfo info in infos.Where(info => "Culture" != info.Name && "ResourceManager" != info.Name))
        {
            string value = info.GetValue(null, null) as string;
            if (value == swiss)
            {
                PropertyInfo englishProperty = englishResources.GetProperty(
                    info.Name,
                    BindingFlags.NonPublic | BindingFlags.Static);
                string english = englishProperty.GetValue(null, null) as string;
                return english;
            }
        }
        return null;
    }
