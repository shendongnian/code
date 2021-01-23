    public static class IMappingOperationOptionsExtensions
    {
        public static void ExcludeMembers(this AutoMapper.IMappingOperationOptions options, params string[] members)
        {
            options.Items[MappingProfile.MemberExclusionKey] = members;
        }
    }
