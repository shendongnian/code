    using System.Collections;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Windows.Forms;`
    namespace InstallerAction
    {
        [RunInstaller(true)]
        public partial class InstallerPathAction : Installer
        {
            //Here override methods that you need for example
            protected override void OnBeforeInstall(IDictionary savedState)
            {
                base.OnBeforeInstall(savedState);
                //Your code and here abort the installation
                throw new InstallException("No master software");
            }
        }
    }
