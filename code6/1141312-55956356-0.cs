       private bool SetRegistery()
        {
            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
                {
                    using (RegistryKey key = hklm.OpenSubKey(@"MIME\Database\Content Type\application/json", true))
                    {
                        if (key != null)
                        {
                            key.SetValue("CLSID", "{25336920-03F9-11cf-8FD0-00AA00686F13}");
                            key.SetValue("Encoding", new byte[] { 0x80, 0x00, 0x00, 0x00 });
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
