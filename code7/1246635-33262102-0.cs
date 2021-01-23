    public static RegistryKey OpenBaseKey(RegistryHive hKey, RegistryView view)
    {
       ValidateKeyView(view);
       return GetBaseKey((IntPtr)((int)hKey), view);
    }
