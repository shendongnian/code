    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            const string key_path = "SOFTWARE\\YourCompany\\YourApplication";
            const string key_value_name = "InstallationDirectory";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(key_path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(key_path);
            }
            string tgt_dir = "someDirectory";
            key.SetValue(key_value_name, tgt_dir);
        }
