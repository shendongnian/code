    List<DomainControllerLists> dcList = new List<DomainControllerLists>();
            using (PowerShell inst = PowerShell.Create())
            {
                inst.AddCommand("Import-Module").AddParameter("Name", "ActiveDirectory");
                inst.AddScript(command);
                Collection<PSObject> results = inst.Invoke();
                foreach (PSObject obj in results)
                {
                    dcList.Add(new DomainControllerLists() { Name = obj.Members["Name"].Value.ToString(), OperatingSystem = obj.Members["OperatingSystem"].Value.ToString(), OperatingSystemServicePack = obj.Members["OperatingSystemServicePack"].Value.ToString(), Site = obj.Members["Site"].Value.ToString() });
                }
            }
            return dcList;
