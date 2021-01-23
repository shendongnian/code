    Mapper.Initialize(cfg => {
      cfg.CreateMap<Domain.ESB.Fault, Models.FaultVmRec>();
      cfg.CreateMap<Models.FaultVmRec, Domain.ESB.Fault>();
      cfg.
      cfg... //so on
    });
