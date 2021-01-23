	Mapper.Initialize(cfg =>
	{
		// necessary if you are mapping parent to a parent
		cfg.CreateMap<Parent, Parent>()
			.ForAllMembers(options =>
			{
				options.Condition(src => src.DestinationValue == null);
			});
		// necessary if you are mapping your child to a child
		cfg.CreateMap<Child, Child>()
			.ForAllMembers(options =>
			{
				options.Condition(src => src.DestinationValue == null);
			});
	});
