    var result = (from inspArch in inspectionArchives
                  from inspAuth in inspArch.InspectionAuthority 
                  group new { inspArch, inspAuth } by inspArch.CustomerId into g
                  select g).AsEnumerable()
                           .Select(g => new 
                            {
                                Id = String.Join(",",g.Select(x => x.inspArch.Id),
                                clientId = x.Key,
                                authId = String.Join(",",g.Select(x => x.inspAuth.Id)
                            }).ToList();
