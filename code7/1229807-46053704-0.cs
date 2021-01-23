    private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
    {
        using (var key = Registry.CurrentUser.CreateSubKey(
            String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature), 
            RegistryKeyPermissionCheck.ReadWriteSubTree))
        {
            key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
        }
    }
