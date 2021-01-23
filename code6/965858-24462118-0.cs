    private void Init()
    {
        m_InitialStartupPrograms = new Dictionary<string, int>();
        LoadDictionary(RegistryHive.LocalMachine, RegistryView.Registry32, m_HKLM_PATH_CODE);
        LoadDictionary(RegistryHive.LocalMachine, RegistryView.Registry64, m_HKLM_PATH_CODE);
        LoadDictionary(RegistryHive.CurrentUser, RegistryView.Registry32, m_HKCU_PATH_CODE);
        LoadDictionary(RegistryHive.CurrentUser, RegistryView.Registry64, m_HKCU_PATH_CODE);
    }
    //Instead of repeating the same code over and over, make a function then just 
    // call the function repeatedly with different parameters.
    private void LoadDictionary(RegistryHive hive, RegistryView view, int pathCode)
    {
        //based on the name m_RegistryKey it appears that those where not local variables.
        //Because you close them right away there is no reason not to make them local
        // variables inside using statements.
        using (var baseKey = RegistryKey.OpenBaseKey(hive, view))
        using (var subKey = baseKey.OpenSubKey(m_REGISTRY_PATH))
        {
            foreach (string startupPrograms in subKey.GetValueNames())
            {
                m_InitialStartupPrograms.Add(startupPrograms, pathCode);
            }
        }
    }
