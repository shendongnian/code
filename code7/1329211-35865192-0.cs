    public class WordPdfImportWarningRemover : IDisposable
    {
        private const string RegistryDirectoryFormat = @"Software\Microsoft\Office\{0}\Word\Options";
        private const string RegistringKeyName = "DisableConvertPdfWarning";
        private object _oldValue;
        private RegistryValueKind _oldValueKind;
        private bool _keyExists;
        private bool _registryExists;
        public WordPdfImportWarningRemover()
        {
            EditRegistry("16.0");
        }
        public WordPdfImportWarningRemover(string version)
        {
            if(version == null)
                throw new ArgumentNullException(nameof(version));
            EditRegistry(version);
        }
        private void EditRegistry(string version)
        {
            RegistryKey officeOptions = Registry.CurrentUser.OpenSubKey(string.Format(RegistryDirectoryFormat, version), true);
            if (officeOptions != null)
            {
                using (officeOptions)
                {
                    _registryExists = true;
                    var keys = officeOptions.GetValueNames();
                    if (keys.Contains(RegistringKeyName))
                    {
                        _keyExists = true;
                        _oldValue = officeOptions.GetValue(RegistringKeyName);
                        _oldValueKind = officeOptions.GetValueKind(RegistringKeyName);
                    }
                    else
                    {
                        _keyExists = false;
                    }
                    officeOptions.SetValue(RegistringKeyName, 1, RegistryValueKind.DWord);
                    officeOptions.Close();
                }
            }
            else
            {
                _registryExists = false;
            }
        }
        public void Dispose()
        {
            if (_registryExists)
            {
                RegistryKey officeOptions = Registry.CurrentUser.OpenSubKey(string.Format(RegistryDirectoryFormat, "16.0"), true);
                if (officeOptions != null)
                {
                    using (officeOptions)
                    {
                        if (_keyExists)
                        {
                            officeOptions.SetValue(RegistringKeyName, _oldValue, _oldValueKind);
                        }
                        else
                        {
                            officeOptions.DeleteValue(RegistringKeyName, false);
                        }
                        officeOptions.Close();
                    }
                }
            }
        }
    }
