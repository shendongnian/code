        var var1 = uow.RoleTypeRepository.Get(p => p.ID == 3).Single().NAME;
        // Detach before reading it
        ((IObjectContextAdapter)uow).ObjectContext.Detach(var1);
        var var2 = uow.RoleTypeRepository.Get(p => p.ID == 3).Single().NAME; 
        
