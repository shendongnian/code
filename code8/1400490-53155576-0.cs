    /// <summary>Properties tagged with the system <see cref="IgnoreDataMemberAttribute"/>
    /// should be ignored by the JSON serializer.
    /// Due to a Newtonsoft JSON bug (https://github.com/JamesNK/Newtonsoft.Json/issues/943)
    /// We need to use their own specific JsonIgnore attribute to effectively ignore a property.
    /// This contract resolver aims to correct that.</summary>
    public class RespectIgnoreDataMemberResolver : DefaultContractResolver
    {
        /// <inheritdoc/>
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            return base.GetSerializableMembers(objectType)
                .Where(pi => !pi.IsAttributeDefinedFast<IgnoreDataMemberAttribute>())
                .ToList();
        }
        /// <inheritdoc/>
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization memberSerialization)
        {
            if (member.IsAttributeDefinedFast<IgnoreDataMemberAttribute>())
                return null;
            return base.CreateProperty(member, memberSerialization);
        }
    }
