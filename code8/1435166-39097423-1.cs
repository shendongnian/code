     int myappid = Process.GetCurrentProcess().Id;
                Process[] processes = Process.GetProcessesByName("EXCEL");          
    
                foreach (Process prs in processes)
                {
                    var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", prs.Id);
                    var search = new ManagementObjectSearcher("root\\CIMV2", query);
                    var results = search.Get().GetEnumerator();
                    results.MoveNext();
                    var queryObj = results.Current;
                    var parentId = (uint)queryObj["ParentProcessId"];
    
                    if (ProcessExists((int)parentId))
                    {
                        var parent = Process.GetProcessById((int)parentId);
                       
                        if (parent.Id == myappid)
                        {
                            prs.Kill();
                        }
                    }
                }
    
     private bool ProcessExists(int id)
            {
                return Process.GetProcesses().Any(x => x.Id == id);
            }
