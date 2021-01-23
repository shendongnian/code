     using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("TechTemp", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                    key.Close();
                }
