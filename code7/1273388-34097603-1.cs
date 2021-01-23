    static class TypeExtensions
    {
        public static IEnumerable<MemberInfo> GetAllInstanceMembers(this Type type)
        {
            if (type == null || type == typeof (object) || !type.IsClass || type.IsInterface)
            {
                return Enumerable.Empty<MemberInfo>();
            }
            IEnumerable<MemberInfo> baseMembers = type.BaseType.GetAllInstanceMembers();
            IEnumerable<MemberInfo> interfacesMembers = type.GetInterfaces().SelectMany(x => x.GetAllInstanceMembers());
            IEnumerable<MemberInfo> currentMembers = type.FindMembers(MemberTypes.Field | MemberTypes.Property,
                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
                AllMemberFilter, null);
            return baseMembers.Concat(interfacesMembers).Concat(currentMembers);
        }
        static readonly MemberFilter AllMemberFilter = (objMemberInfo, objSearch) => true;
    }
