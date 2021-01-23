        private void RunWindowsStartup(object sender, EventArgs e)
        {
            var menuItem = ((MenuItem)(sender));
            menuItem.Checked = !menuItem.Checked;
            RegisterInStartup(menuItem.Checked);
        }
        private static void RegisterInStartup(bool isChecked)
        {
            try
            {
                var appName = AppDomain.CurrentDomain.FriendlyName.Split('.')[0];
                using (var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (registryKey == null) return;
                    if (isChecked)
                    {
                        registryKey.SetValue(appName, Application.ExecutablePath);
                    }
                    else
                    {
                        registryKey.DeleteValue(appName);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.CreateFile(ex);
                TlMessageBox.Show(ex.Message, "Error", TlMessageBoxButtons.OK, TlMessageBoxIcon.Error, ex.StackTrace);
            }
        }
