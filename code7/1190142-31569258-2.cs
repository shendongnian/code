     string[] roles = {"admin","medewerker"};       
            _medewerkers = contactPersoonRepository
                .Query(c => c.Bedrijf.BEDRIJF_TYPE.Contains("P") && roles.Contains(c.CP_ROLE))
                .NoTracking()
                .OrderBy(q => q.OrderBy(d => d.CP_NAAM))
                .Select(b => new Medewerker
                {
                    Naam = b.CP_NAAM,
                    VoorNaam = b.CP_VOORNM,
                    Id = b.CP_CPID,
                    Rol = b.CP_ROLE,
                    Uurloon = b.CP_UURLOON
                }).ToList();
