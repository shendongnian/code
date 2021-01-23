    public class MimeMessageContractResolver : DefaultContractResolver
    {
        private static HashSet<string> excludedMembers = new HashSet<string>
        {
            "ResentMessageId",
            "MimeVersion"
        };
        
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var baseMembers = base.GetSerializableMembers(objectType);        
            
            if (typeof(MimeMessage).IsAssignableFrom(objectType)) 
            {
                baseMembers.RemoveAll(m => excludedMembers.Contains(m.Name));
            }
            
            return baseMembers;
        }
    }
