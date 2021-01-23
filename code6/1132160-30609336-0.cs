    public class Example
    {
         private readonly ICloudSettingsProvider _cloudSettingsProvider;
         public void DoWork(){
             var setting = __cloudSettingsProvider.GetConfigurationSetting(
                            () => Properties.Setting.Default.ExampleConfiguration);
         }
    }
