    BandProfile = ctx.BandProfiles.Where(u => u.UserId == UserId).Select(x => new Profile(){Id = x.Id, Name = x.Name}).ToList();
    
    MusicanProfile = ctx.MusicanProfiles.Where(u => u.UserId == UserId).Select(x => new Profile(){Id = x.Id, Name = x.Name}).ToList();
    
    RegularProfile = ctx.RegularProfiles.Where(u => u.UserId == UserId).Select(x => new Profile(){Id = x.Id, Name = x.Name}).ToList();
