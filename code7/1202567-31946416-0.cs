    public static class SettingsExtensions
    {
        public bool IsUserScoped(this Settings settings, string variableName)
        {
            PropertyInfo pi = settings.GetType().GetProperty(variableName, BindingFlags.Instance);
            return pi.GetCustomAttribute<System.Configuration.UserScopedSettingAttribute>() != null;
        }
    }
