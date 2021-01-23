    using System;
    using System.Windows.Forms;
    using Microsoft.Win32;
    static class Program
    {
        [STAThread]
        static void Main()
        {
    #if DISABLETASKMGR
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    #endif
        }
    }
