    private static bool CanProxyType(EntityType ospaceEntityType)
    {
        var clrType = ospaceEntityType.ClrType;
        if (!clrType.IsPublic()
            || clrType.IsSealed()
            || typeof(IEntityWithRelationships).IsAssignableFrom(clrType)
            || ospaceEntityType.Abstract)
        {
            return false;
        }
        var ctor = clrType.GetDeclaredConstructor();
        return ctor != null && (((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public) ||
                                ((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family) ||
                                ((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem));
    }
