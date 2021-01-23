            var key = Registry.LocalMachine
                .OpenSubKey("Software")
                .OpenSubKey("Microsoft")
                .OpenSubKey("Windows")
                .OpenSubKey("CurrentVersion")
                .OpenSubKey("Uninstall");
            
            foreach(var n in key.GetSubKeyNames())
            {
                var name = key.OpenSubKey(n).GetValue("DisplayName");
                if (name != null) 
                {
                    Console.WriteLine(name);
                }
                else
                {
                    Console.WriteLine(n);
                }
            }
