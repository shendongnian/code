	public static class Mappings
	{
		public static void Initialize()
		{
			DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
			DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
			{
				typeof(Mappings).Assembly
			});
		}
		public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T>
		where T : class 
		{
			...
		}
		public class LibraryInfoMapper : ClassMapper<LibraryInfo>
		{
			...
		}
	}
