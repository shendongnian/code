            try
            {
                WqlObjectQuery sql = new WqlObjectQuery("SELECT * FROM Win32_PrintJob");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(sql);
                foreach (ManagementObject printJob in searcher.Get())
                {
                    if (!prevJobName.Equals(printJob["Name"]))
                    {
                        Console.WriteLine(printJob["Name"] + ":" + printJob["Status"]);
                        printJob.InvokeMethod("Pause", null);
                        prevJobName = (String)printJob["Name"];
                        Interop.ShowMessageBox("Click Ok To continue", "MyService Message");
                        printJob.InvokeMethod("Resume", null);
                    }
                }
			}
            catch (Exception ex)
            {
                this.EventLog.WriteEntry(ex.ToString());
            }
