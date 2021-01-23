    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        // ...
    
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime LastCalibrationTime {
            get {
                return ((global::System.DateTime)(this["LastCalibrationTime "]));
            }
            set {
                this["LastCalibrationTime "] = value;
            }
        }
    }
