            SpIMDLists.InformationManagementDivisionDataContext dc = new SpIMDLists.InformationManagementDivisionDataContext(new Uri("https://myurl/SiteDirectory/IMD/_vti_bin/ListData.svc/"));
            dc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            var source = dc.Tasks;
            
            
            foreach (var task in source.Expand("AssignedTo")
            {
                string taskTitle = task.Title;
                string taskDesc = task.TaskDescription;
                string taskDueDate = task.DueDate.ToString();
                string taskStartDate = task.StartDate.ToString();
                string taskStatusValue = task.StatusValue;
                string taskOutcome = task.TaskOutcome;
                var assignedTo = task.AssignedTo;
                foreach (var usr in assignedTo)
                {
                    string taskAssignedTo = usr.Name;
                }
                
             }
                
  
