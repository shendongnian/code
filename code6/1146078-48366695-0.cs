        <ComRegisterFunction()>
    Private Shared Sub ComRegister(ByVal t As Type)
        Dim keyName As String = "CLSID\\" & t.GUID.ToString("B")
        Dim key As RegistryKey = Registry.ClassesRoot.OpenSubKey(keyName, True)
        key.CreateSubKey("Control").Close()
        Dim subkey As RegistryKey = key.CreateSubKey("MiscStatus")
        subkey.SetValue("", "131201")
        subkey = key.CreateSubKey("TypeLib")
        Dim libid As Guid = Marshal.GetTypeLibGuidForAssembly(t.Assembly)
        subkey.SetValue("", libid.ToString("B"))
        subkey = key.CreateSubKey("Version")
        Dim ver As Version = t.Assembly.GetName().Version
        Dim version As String = String.Format("{0}.{1}", ver.Major, ver.Minor)
        If version = "0.0" Then version = "1.0"
        subkey.SetValue("", version)
        subkey = key.CreateSubKey("InprocServer32")
        'MsgBox(Environment.SystemDirectory + "\\" + subkey.GetValue("", "mscoree.dll"))
        'C:\WINDOWS\SysWow64\mscoree.dll
        'subkey.SetValue("", Environment.SystemDirectory + "\" + "mscoree.dll")
        subkey.SetValue("", "C:\Windows\System32\mscoree.dll")
    End Sub
