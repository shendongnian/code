    // find the installed SQL Server instance names
    RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");
    // loop over those instances
    foreach (string sqlInstance in key.GetValueNames())
    {
        Console.WriteLine("SQL Server instance: {0}", sqlInstance);
        // find the SQL Server internal name for the instance
        string internalName = key.GetValue(sqlInstance).ToString();
        Console.WriteLine("\tInternal instance name: {0}", internalName);
        // using that internal name - find the "Setup" node in the registry
        string instanceSetupNode = string.Format(@"SOFTWARE\Microsoft\Microsoft SQL Server\{0}\Setup", internalName);
        RegistryKey setupKey = baseKey.OpenSubKey(instanceSetupNode, false);
        if (setupKey != null)
        {
            // in the "Setup" node, you have several interesting items, like
            // * edition and version of that instance
            // * base path for the instance itself, and for the data for that instance
            string edition = setupKey.GetValue("Edition").ToString();
            string pathToInstance = setupKey.GetValue("SQLBinRoot").ToString();
            string version = setupKey.GetValue("Version").ToString();
            Console.WriteLine("\tEdition         : {0}", edition);
            Console.WriteLine("\tVersion         : {0}", version);
            Console.WriteLine("\tPath to instance: {0}", pathToInstance);
        }
    }
