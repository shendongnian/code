    var bpQuery =
        from f in _CEMDbContext.setFac
        join sli in _CEMDbContext.setSitLocInt on f.FacId equals sli.FacId
        join ei in _CEMDbContext.setEnvInt on sli.EnvIntId equals ei.EnvIntId into eiGroup
        from eig in eiGroup.DefaultIfEmpty().Where(e => e.EnvIntTyp.EnvIntTyp == "Fleet")
        join a in _CEMDbContext.setAff on eig.EnvIntId equals a.EnvIntId into aGroup
        from ag in aGroup.DefaultIfEmpty()
        join ac in _CEMDbContext.setAffCon.DefaultIfEmpty() on ag.AffId equals ac.AffId into acGroup
        from acg in acGroup.DefaultIfEmpty()
        join c in _CEMDbContext.setCon.DefaultIfEmpty() on acg.ConId equals c.ConId into cGroup
        from cg in cGroup.DefaultIfEmpty()
        join p in _CEMDbContext.setPho.DefaultIfEmpty() on cg.ContactId equals p.ConId into pGroup
        from pg in pGroup.DefaultIfEmpty()
        select new BusinessParticipant
        {
            facility = f,
            sitLocInt = sli,
            envInt = eig,
            pho = pg,
        };                        
        BusinessParticipantList = bpQuery.ToList();
