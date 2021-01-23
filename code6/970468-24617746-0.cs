    namespace TestApp
    {
        public class InstallerTest
        {
            public static void Install()
            {
                Type type = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer installer = (Installer)Activator.CreateInstance(type);
                installer.InstallProduct("YourPackage.msi");
            }
        }
    }
