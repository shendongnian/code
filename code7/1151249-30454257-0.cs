        [ComRegisterFunctionAttribute]
        public static void Register(Type type)
        {
            string guid = type.GUID.ToString("B");
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(BHOKEYNAME, true);
            if (registryKey == null)
                registryKey = Registry.LocalMachine.CreateSubKey(BHOKEYNAME);
            RegistryKey ourKey = registryKey.OpenSubKey(guid);
            if (ourKey == null)
                ourKey = registryKey.CreateSubKey(guid);
            RegistryKey addonNameKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\" + guid, true);
            if (addonNameKey == null)
                addonNameKey = Registry.LocalMachine.CreateSubKey(@"CLSID\" + guid);
            addonNameKey.SetValue("", "ESSO");
            addonNameKey.Close();
            ourKey.SetValue("NoExplorer", 1);
            registryKey.Close();
            ourKey.Close();
        }
