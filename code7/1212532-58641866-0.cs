    public static void DeleteRegistryFolder(RegistryHive registryHive, string fullPathKeyToDelete)
    {
        using (var baseKey = RegistryKey.OpenBaseKey(registryHive, RegistryView.Registry64))
        {
            baseKey.DeleteSubKeyTree(fullPathKeyToDelete);
        }
    }
