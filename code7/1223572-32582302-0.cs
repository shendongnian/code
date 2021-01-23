        public static bool SetAllowUnsafeHeaderParsing20(bool value)
        {
            //Get the assembly that contains the internal class
            var aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly == null) return false;
            //Use the assembly in order to get the internal type for the internal class
            var aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
            if (aSettingsType == null) return false;
            //Use the internal static property to get an instance of the internal settings class.
            //If the static instance isn't created allready the property will create it for us.
            var anInstance = aSettingsType.InvokeMember("Section",
                                                         BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic,
                                                         null,
                                                         null, 
                                                         new object[] { });
            if (anInstance == null) return false;
            //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
            var aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
            if (aUseUnsafeHeaderParsing == null) return false;
            aUseUnsafeHeaderParsing.SetValue(anInstance, value);
            return true;
        }
