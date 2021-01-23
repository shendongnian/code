    var porjDetails = (from pd in SBDB.ProjDetails   
                       where pd.EmployeeId == empId && pd.ManagerId == managerId              
                       select new EmpProject{
                          EmpId = pd.EmployeeId,
                          ManagerId = empProject.ManagerId,
                          ProjectIds = SBDB.Projects.where(p=>p.ProjectId == pd.ProjectId).Select(p=>p.Id),
                          ProjectNames = SBDB.Projects.where(p=>p.ProjectId == pd.ProjectId).Select(p=>p.Name)
                       });
