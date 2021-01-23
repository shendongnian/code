    context
        .TableA
        .Select(s => new TableA_DTO
        {
            IdTableA = s.IdTableA,
            OtherInfo = s.OtherInfo,
            IdTableB = s.IdTableB,
            TableB = new TableB_DTO
            {
                IdTableB = (s.TableB != null) ? s.TableB.IdTableB : null,
                Description = (s.TableB != null) ? s.TableB.Description : null
            }
        }).ToList();
