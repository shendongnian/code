    modelBuilder.Entity<Department>() 
        .Map(m => 
        { 
            m.Properties(t => new { t.DepartmentID, t.Name }); 
            m.ToTable("Department"); 
        }) 
        .Map(m => 
        { 
            m.Properties(t => new { t.DepartmentID, t.Administrator, t.StartDate, t.Budget }); 
            m.ToTable("DepartmentDetails"); 
        });
