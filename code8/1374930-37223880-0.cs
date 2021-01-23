         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
         System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
         // If you're an administrator
         if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
         {
            // Then run the application (first time)
            Application.Run(new HomePage());
         }
         else
         {
             System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
             startInfo.UseShellExecute = true;
             startInfo.WorkingDirectory = Environment.CurrentDirectory;
             startInfo.FileName = Application.ExecutablePath;
             startInfo.Verb = "runas";
             try
             {
                 System.Diagnostics.Process.Start(startInfo);
                 Application.Exit();
             }
             catch
             {
                 return;
             }
             Application.Exit();
         }
       // you end up here after it ran as an admin, skipping the else and you tell it to run again, either remove that line or invert your condition
      Application.Run(new HomePage());
