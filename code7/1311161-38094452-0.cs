	public static class AutoMapperConfig
	{
		public static IMapperConfigurationExpression AddAdminMapping(
			this IMapperConfigurationExpression configurationExpression)
		{
			configurationExpression.CreateMap<Job, JobRow>()
				.ForMember(x => x.StartedOnDateTime, o => o.PreCondition(p => p.StartedOnDateTimeUtc.HasValue))
				.ForMember(x => x.StartedOnDateTime, o => o.MapFrom(p => p.StartedOnDateTimeUtc.Value.DateTime.ToLocalTime()))
				.ForMember(x => x.FinishedOnDateTime, o => o.PreCondition(p => p.FinishedOnDateTimeUtc.HasValue))
				.ForMember(x => x.FinishedOnDateTime, o => o.MapFrom(p => p.FinishedOnDateTimeUtc.Value.DateTime.ToLocalTime()));
			return configurationExpression;
		}
	}
