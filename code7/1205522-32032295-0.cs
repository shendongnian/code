            var key = Registry.LocalMachine
                .OpenSubKey("Software")
                .OpenSubKey("Microsoft")
                .OpenSubKey("Windows")
                .OpenSubKey("CurrentVersion")
                .OpenSubKey("Uninstall");
            
            foreach(var n in key.GetSubKeyNames())
            {
                var k = key.OpenSubKey(n);
                var name = k.GetValue("DisplayName");
                if (name != null) {
                    Console.WriteLine(name);
                }
            }
