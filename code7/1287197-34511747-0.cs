    protected override void Seed(eVendContext context) 
    {
        
        if (!context.Stations.Any())
        {   
              context.Stations.AddOrUpdate(p => p.Name,
              new eVendDbDataModel.Models.Station() {
                  Name = "Test Station 1",
                  Active = true,
                  Created = DateTime.Now,
                  Modified = DateTime.Now,
                  Returnable = false,
                  Type = "Test",
                  PortNo = "COM1",
                  Parse = false,
                  UseJob = true,
                  UseDept = true,
                  JobAlias = "Job Number",
                  DeptAlias = "Department",
                  SiteId = 1
              });
            context.SaveChanges();
        }
    }
