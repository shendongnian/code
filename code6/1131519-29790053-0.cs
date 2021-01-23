    var Join = (from a in DC.tblEmployeeLoginDetails
               join b in DC.tblProjects
               on a.LoginID equals b.ProjectID
               join c in DC.tblClientLoginDetails
               on b.ProjectID equals c.ClientLoginID
               where c.ClientLoginID != null
               select new
                        { 
                            ProjectID = b.ProjectID, 
                             ProjectName = b.ProjectName, 
                            ProjectStatus = b.ProjectStatus, 
                            EmployeeName = a.EmployeeName, 
                            EmployeeSurname = a.EmployeeSurname,
                            ClientName = c.ClientName,
                        }).ToList().Select(x => new PIDData
                       {
             ProjectID = b.ProjectID, 
             Name = b.ProjectName, 
              Status = b.ProjectStatus, 
                       }).ToList() ;
