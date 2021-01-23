    var wmiQueryString = string.Format("select * from CIM_ProcessExecutable");
    Dictionary<int, ProcInfo> procsMods = new Dictionary<int, ProcInfo>();
    using (var searcher = new ManagementObjectSearcher(string.Format(wmiQueryString)))
    using (var results = searcher.Get())
    {
        foreach (var item in resMg.Cast<ManagementObject>())
        {
            try
            {
                var antecedent = new ManagementObject((string)item["Antecedent"]);
                var dependent = new ManagementObject((string)item["Dependent"]);
                int procHandleInt = Convert.ToInt32(dependent["Handle"]);
                ProcInfo pI = new ProcInfo { Handle = procHandleInt, FileProc = new FileInfo((string)dependent["Name"]) };
                if (!procsMods.ContainsKey(procHandleInt))
                {
                    procsMods.Add(procHandleInt, pI);
                }
                procsMods[procHandleInt].Modules.Add(new ModInfo { FileMod = new FileInfo((string)antecedent["Name"]) });
            }
            catch (System.Management.ManagementException ex)
            {
                // Process does not exist anymore
            }
        }
    }
