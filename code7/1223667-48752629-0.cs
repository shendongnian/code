	class DataContractJsonResolver : DefaultContractResolver
	{
		public DataContractJsonResolver()
		{
			NamingStrategy = new CamelCaseNamingStrategy();
		}
		protected override IList<JsonProperty> CreateProperties( Type type, MemberSerialization memberSerialization )
		{
			return base.CreateProperties( type, memberSerialization )
				.OrderBy( p => BaseTypesAndSelf( p.DeclaringType ).Count() ).ToList();
			IEnumerable<Type> BaseTypesAndSelf( Type t )
			{
				while ( t != null ) {
					yield return t;
					t = t.BaseType;
				}
			}
		}
	}
