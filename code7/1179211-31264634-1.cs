    protected override void OnBeforeInstall(IDictionary savedState)
    {
        _eventLog.WriteEntry("OnBeforeInstall Started");
        try
        {
            RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\RMS");
            if (key != null)
            {
                _eventLog.WriteEntry("Write data to registry key");
    
                Process _prc = new Process();
                _prc.StartInfo.FileName = "cmd.exe";
                _prc.StartInfo.UseShellExecute = false;
                _prc.StartInfo.RedirectStandardOutput = true;
                _prc.StartInfo.RedirectStandardInput = true;
                _prc.Start();
    
                ConsoleColor _color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n");
                Console.WriteLine("PLEASE ENTER FOLLOWING DETAILS TO COMPLETE SETUP");
                Console.WriteLine("NOTE: if you enter wrong information, you will need to reinstall the application.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Enter DBTYPE (SQLSERVER or ORACLE):");
                key.SetValue("DBTYPE", StringCipher.Encrypt(Console.ReadLine(), "@xx"));
                Console.WriteLine("Enter DATASOURCE (SERVER NAME):");
                key.SetValue("DATASOURCE", StringCipher.Encrypt(Console.ReadLine(), "@xx"));
                Console.WriteLine("Enter DATABASE USER ID:");
                key.SetValue("USERID", StringCipher.Encrypt(Console.ReadLine(), "@xx"));
                Console.WriteLine("Enter PASSWORD:");
                key.SetValue("PASSWORD", StringCipher.Encrypt(Console.ReadLine(), "@xx"));
                Console.WriteLine("Enter DATABASE NAME:");
                key.SetValue("DBNAME", StringCipher.Encrypt(Console.ReadLine(), "@xx"));
                key.Close();
                Console.ForegroundColor = _color;
                _prc.Close();
            }
        }
        catch (Exception ex)
        {
            _eventLog.WriteEntry(ex.Message);
        }
        _eventLog.WriteEntry("OnBeforeInstall Finished");
        base.OnBeforeInstall(savedState);
    }
