    public class CloudSettingsProvider : ICloudSettingsProvider
    {
        public T GetConfigurationSetting<T>(Expression<Func<T>> setting)
        {
            Guard.ArgumentNotNull(setting, "setting");
            var settingNames = new List<string>();
            T settingDefaultValue;
            #region Parse settingNames / settingDefaultValue from setting Expression
            try
            {
                var memberExpression = (MemberExpression) setting.Body;
                //////Setting Name
                var settingName = memberExpression.Member.Name;
                if (string.IsNullOrEmpty(settingName))
                    throw new Exception("Failed to get Setting Name (ie Property Name) from Expression");
                settingNames.Add(settingName);
                //////Setting Full Name
                var memberReflectedType = memberExpression.Member.ReflectedType;
                if (null != memberReflectedType)
                    //we can use the settings full namespace as a search candidate as well
                    settingNames.Add(memberReflectedType.FullName + "." + settingName);
                //////Setting Default Value
                settingDefaultValue = setting.Compile().Invoke();
            }
            catch (Exception e)
            {
                #region Wrap and Throw
                throw new Exception("Failed to parse Setting expression.  " +
                                    "Expression should be like [() => Properties.Setting.Default.Foo]: " + e.Message,
                                    e);
                #endregion
            }
            #endregion
            return GetConfigurationSettingInternal(
                settingDefaultValue,
                settingNames.ToArray());
        }      
        private T GetConfigurationSettingInternal<T>(T defaultvalue = default(T), params string[] configurationSettingNames)
        {
            Guard.ArgumentNotNullOrEmptyEnumerable(configurationSettingNames, "configurationSettingNames");
            //function for converting a string setting found in the 
            //<appConfig> or azure config to type T
            var conversionFunc = new Func<string, T>(setting =>
            {
                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), setting);
                if (!typeof(T).IsClass || typeof(T) == typeof(string))
                    //value type
                    return (T)Convert.ChangeType(setting, typeof(T));
                //dealing with a complex custom type, so let's assume it's
                //been serialized into xml. 
                return
                    setting
                        .UnescapeXml()
                        .FromXml<T>();
            });
            ///////////////
            // Note: RoleEnvironment isn't always available in Unit Tests
            //   Fixing this by putting a general try/catch and returning the defaultValue
            //////////////
            try
            {
                if (!RoleEnvironment.IsAvailable)
                {
                    //Check the <appSettings> element.
                    var appConfigValue =
                        configurationSettingNames
                            .Select(name => ConfigurationManager.AppSettings[name])
                            .FirstOrDefault(value => !string.IsNullOrEmpty(value));
                    return !string.IsNullOrEmpty(appConfigValue)
                        ? conversionFunc(appConfigValue)
                        : defaultvalue;
                    
                }
                
                //Note: RoleEnvironment will fallback to <appConfig>
                //http://stackoverflow.com/questions/11548301/azure-configuration-settings-and-microsoft-windowsazure-cloudconfigurationmanage
                var azureConfigValue =
                    configurationSettingNames
                            .Select(name => RoleEnvironment.GetConfigurationSettingValue(name))
                            .FirstOrDefault(value => !string.IsNullOrEmpty(value));
                return !string.IsNullOrEmpty(azureConfigValue)
                        ? conversionFunc(azureConfigValue)
                        : defaultvalue;
            }
            catch (InvalidCastException e)
            {
                _Logger.Warning(
                    string.Format(
                        "InvalidCastException getting configuration setting [{0}]." +
                        "This generally means the value entered is of the wrong type (ie " +
                        "it wants an Int, but the config value has non-numeric characters: {1}",
                            configurationSettingNames, e.Message), e);
            }
            catch (Exception e)
            {
                _Logger.Warning(
                    string.Format(
                        "Unhandled Exception getting configuration setting [{0}]: {1}",
                            configurationSettingNames, e.Message), e);
            }
            
            //If we are here, we hit an exception so return default value
            return defaultvalue;
        }
