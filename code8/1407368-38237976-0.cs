    Mapper.CreateMap<Agenda, AgendaViewModel>()
            .ForMember(x => x.DateApproved, 
                        y => y.ResolveUsing(z => z.DateApproved.HasValue 
                               ? DateTime.UtcNow :
                               Mapper.Map<Agenda, AgendaViewModel>
                              (DateTime.SpecifyKind(z.DateApproved.Value, DateTimeKind.Utc)));
