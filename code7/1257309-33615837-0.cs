    public static string GetMASM32LocationFromRegistry()
    {
        RegistryKey localMachineRegistryKey;
        RegistryKey masm32RegistryKey;
        RegistryView currentRegistryView = RegistryView.Registry64;
        localMachineRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, currentRegistryView);
        masm32RegistryKey = localMachineRegistryKey.OpenSubKey(@"SOFTWARE\Wow6432Node\MASM32");
        if (masm32RegistryKey == null)
        {
            return @"ERROR: The registry key HKLM\SOFTWARE\Wow6432Node\MASM32 could not be found";
        }
        StringBuilder masm32RegistryKeyValuesBuilder = new StringBuilder("Key/Value pairs for registry key HKLM\\SOFTWARE\\Wow6432Node\\MASM32:\r\n");
        foreach (string masm32RegistryKeyValueName in masm32RegistryKey.GetValueNames())
        {
            masm32RegistryKeyValuesBuilder.AppendFormat
            (
                "Key: [{0}], Value: [{1}], Value Type: [{2}]\r\n",
                masm32RegistryKeyValueName,
                masm32RegistryKey.GetValue(masm32RegistryKeyValueName),
                masm32RegistryKey.GetValueKind(masm32RegistryKeyValueName)
            );
        }
        return masm32RegistryKeyValuesBuilder.ToString();
    }
