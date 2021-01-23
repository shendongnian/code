    public class MySettings : System.Configuration.ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("Value1")]
        public string Key1
        {
            get
            {
                return ((string)this["Key1"]);
            }
            set
            {
                this["Key1"] = value;
            }
        }
    }
