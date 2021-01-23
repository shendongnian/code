    modelBuilder.Entity<Contract>() 
        .Map(m => 
        { 
            m.Properties(c => new { c.CustomerId, c.ContractId }); 
            m.ToTable("T_CONTRACTS"); 
        }) 
        .Map(m => 
        { 
            m.Properties(p => new { p.PersonID, p.Name }); 
            m.ToTable("T_PERSONS"); 
        });
