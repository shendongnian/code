    var finalComptes =  (comptes.AsEnumerable()
                    .Select((comptes, index) => new GridCompte()
                            {
                                SocCompteId = c.IdCompte,                               
                                Name = c.Name,
                                Nb = index + 1,
                                .....
                                SocName = s.Name                               
                            }).ToList();
