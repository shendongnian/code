        //This line open Registry with x64 View from x86 process. Usually SQL server installed in x64 edition, otherwise you should check x86
        var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        var msSQLServer = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
        var instances = (string[])msSQLServer.GetValue("InstalledInstances");
        foreach (var instance in instances)
        {
            var insNames = localMachine.OpenSubKey(@"Software\Microsoft\Microsoft SQL Server\Instance Names\SQL");
            var realNameInstanse = (string)insNames.GetValue(instance);
            var sqlEditionRegistry = localMachine.OpenSubKey(string.Format(@"Software\Microsoft\Microsoft SQL Server\{0}\Setup", realNameInstanse));
            var edition = (string)sqlEditionRegistry.GetValue("Edition");
            Console.WriteLine("Instance {0}, RealName {2}, - Edition: {1}", instance, edition, realNameInstanse);
        }
        Console.ReadKey();
