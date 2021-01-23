    public static void NewRecords()
            {
                using (var stageContext = new StagingTableDataContext())
                {
                    using (var destinationContext = new DestinationTableDataContext())
                    {
                        var allProjectNames = destinationContext.THEOPTIONs.Select(u => u.NAME).ToList(); 
                        var deltaList = stageContext.ProjectMasters.ToList().Where(u => !allProjectNames.Contains(u.Finance_Project_Number)).ToList();
    
                        deltaList.ForEach(u => u.Processing_Result = 0);
                        deltaList.ForEach(u => u.Processing_Result_Text = "UNIQUE");
    
                    }
                    stageContext.SubmitChanges();
                }
            }
