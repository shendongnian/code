	public static class AutoMapperWebConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfile(new WebProfile());
				cfg.AddProfile(new RepositoryProfile());
			});
			Mapper.AssertConfigurationIsValid();
		}
	}
	public class WebProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<Repository.Model.Item, MVC5.Models.Vare>()
				.ForMember(i => i.Navn, opt => opt.MapFrom(c => c.Varenavn))
				.ForMember(i => i.Nummer, opt => opt.MapFrom(c => c.Varenummer))
				.ForMember(i => i.Leverandør, opt => opt.MapFrom(c => c.Leverandør))
				.ForMember(i => i.Indkøbsaktiv, opt => opt.MapFrom(c => c.Indkøbsaktiv))
				.Ignore(record => record.Salgspris)
				.Ignore(record => record.Lager)
				.Ignore(record => record.Antal);			
		}
	}
	public class RepositoryProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.Initialize(
				cfg => cfg.CreateMap<CacheInfo, Item>()
					.ForMember(i => i.Varenavn, opt => opt.MapFrom(c => c.VareNavn))
					.ForMember(i => i.Varenummer, opt => opt.MapFrom(c => c.VareNummer))
					.ForMember(i => i.Leverandør, opt => opt.MapFrom(c => c.Leverandør))
					.ForMember(i => i.Indkøbsaktiv, opt => opt.ResolveUsing<IndkobsaktivResolver>())
			);
		
