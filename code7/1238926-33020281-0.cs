    var result = (from inspArch in inspectionArchives
             from inspAuth in inspArch.InspectionAuthority               
             select new 
             {
                Id = inspArch.Id,
                clientId = inspArch.CustomerId,
                authId = inspAuth.Id
             })
    .GroupBy(g => g.clientId)
    .select(s => new {
        Id = string.Join(",", s.Select(ss => ss.Id.ToString())),
        ClientId = s.Key,
        AuthId = string.Join(",", s.Select(ss => ss.authId.ToString()).Distinct()),
    }).ToList();
