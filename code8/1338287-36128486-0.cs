        var var1 = uow.RoleTypeRepository.Get(p => p.ID == 3).Single().NAME;
        // Refresh before reading it
        uow.Entry(var1).Reload();
        var var2 = uow.RoleTypeRepository.Get(p => p.ID == 3).Single().NAME;
        
