        [ComRegisterFunction()]
        public static void RegisterFunction(Type _type)
        {
            // Check your class type here 
            if (_type != null )
            {
                string sCLSID = "CLSID\\" + _type.GUID.ToString("B");
                try
                {
                    RegistryKey _key = Registry.ClassesRoot.OpenSubKey(sCLSID, true);
                    try
                    {
                        Guid _libID = Marshal.GetTypeLibGuidForAssembly(_type.Assembly);
                        int _major, _minor;
                        Marshal.GetTypeLibVersionForAssembly(_type.Assembly, out _major, out _minor);
                        using (RegistryKey _sub = _key.CreateSubKey("Control")) { }
                        using (RegistryKey _sub = _key.CreateSubKey("MiscStatus")) { _sub.SetValue("", "0", RegistryValueKind.String); }
                        using (RegistryKey _sub = _key.CreateSubKey("TypeLib")) { _sub.SetValue("", _libID.ToString("B"), RegistryValueKind.String); }
                        using (RegistryKey _sub = _key.CreateSubKey("Version")) { _sub.SetValue("", String.Format("{0}.{1}", _major, _minor), RegistryValueKind.String); }
                        using (RegistryKey _sub = _key.CreateSubKey("Control")) { }
                        
                        using (RegistryKey _sub = _key.CreateSubKey("InprocServer32")) { _sub.SetValue("", Environment.SystemDirectory + "\\" + _sub.GetValue("", "mscoree.dll"), RegistryValueKind.String); }
                    }
                    finally
                    {
                        _key.Close();
                    }
                }
                catch
                {
                }
            }
        }
