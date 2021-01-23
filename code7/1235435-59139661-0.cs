    public class MyJsonContractResolver : DefaultContractResolver
    {
      protected override List<MemberInfo> GetSerializableMembers(Type objectType)
      {
        return base.GetSerializableMembers(objectType)
          .Where(mi => mi.GetCustomAttribute<JsonIgnoreSerializeAttribute>() == null)
          .ToList();
      }
    }
