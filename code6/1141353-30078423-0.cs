                ConnectionOptions connOptions = new ConnectionOptions();
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", NetworkName), connOptions);
                manScope.Connect();
                ProcessName = ProcessName + ".exe";
                using (var searcher = new ManagementObjectSearcher(manScope, new SelectQuery("select * from Win32_Process where Name = '" + ProcessName + "'")))
                {
                    foreach (ManagementObject process in searcher.Get())
                    {
                        process.InvokeMethod("Terminate", null);
                    }
                }
            }
            catch (ManagementException err)
            {
                //Do something with error message here
            }
