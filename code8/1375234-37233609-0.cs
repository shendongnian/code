    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            {
                using (var key = hklm.OpenSubKey(@"Software\Microsoft\VisualStudio\12.0\ProjectMRUList"))
                {
                    string data2 = (string)key.GetValue("File1".ToUpper());
                }
            }
