    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            const string key_path = "SOFTWARE\\VendorName\\MyAppName";
            const string key_value_name = "InstallationDirectory";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(key_path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(key_path);
            }
            string tgt_dir = Context.Parameters["TARGETDIR"];
            key.SetValue(key_value_name, tgt_dir);
        }
