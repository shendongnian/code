	public class JsonIgnoreAttributeIgnorerContractResolver : DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			var property = base.CreateProperty(member, memberSerialization);
			property.Ignored = false; // Here is the magic
			return property;
		}
	}
