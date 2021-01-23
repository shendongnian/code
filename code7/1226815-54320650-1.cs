    public static TType GetAppSettings<TType>(string key, TType defaultValue = default(TType))
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return defaultValue;
                AppSettingsReader appSettings = new AppSettingsReader();
                return (TType)appSettings.GetValue(key, typeof(TType));
            }
            catch
            {
                return defaultValue;
            }
        }
