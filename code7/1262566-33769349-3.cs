	public static class Mappings
	{
		public static void Initialize()
		{
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
			DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
			{
				typeof(Mappings).Assembly
			});
		}
		public class LibraryInfoMapper : ClassMapper<LibraryInfo>
		{
			public LibraryInfoMapper()
			{
				Table("LibraryInfo");
				AutoMap();
			}
		}
	}
