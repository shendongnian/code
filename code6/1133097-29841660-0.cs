        // *********************Below is a TopShelf code*****************************//
        HostFactory.Run(hostConfigurator =>
        {
            ...
            hc.AfterInstall(ihc =>
            {
                using (RegistryKey system = Registry.LocalMachine.OpenSubKey("System"))
                using (RegistryKey currentControlSet = system.OpenSubKey("CurrentControlSet"))
                using (RegistryKey services = currentControlSet.OpenSubKey("Services"))
                using (RegistryKey service = services.OpenSubKey(ihc.ServiceName, true))
                {
                    const String v = "ImagePath";
                    var imagePath = (String)service.GetValue(v);
                    service.SetValue(v, imagePath + String.Format(" -department \"{0}\"", department));
                }
            });
            ...
        }
