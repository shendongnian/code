			CreateMap<SourceType, DestType>()
				.ForMember(
					dst => dst.Property1,
					opt.SetMappingOrder(0))
				.ForMember(
					dst => dst.Property2,
					opts =>
					{
						opts.SetMappingOrder(20);
						opts.ResolveUsing<ResolverThatNeedsProperty1ToBeMappedAlready>();
					});
