    public class IncludeNonPublicMembersContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type type)
        {
            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));
            members.AddRange(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));
            return members;
        }
    }
    docStore.Conventions.JsonContractResolver = new IncludeNonPublicMembersContractResolver();
