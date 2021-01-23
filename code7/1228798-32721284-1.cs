    private static bool CanProxyType(EntityType ospaceEntityType)
    {
        TypeAttributes access = ospaceEntityType.ClrType.Attributes & TypeAttributes.VisibilityMask;
 
        ConstructorInfo ctor = ospaceEntityType.ClrType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance, null, Type.EmptyTypes, null);
        bool accessableCtor = ctor != null && (((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public) ||
                                                ((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family) ||
                                                ((ctor.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem));
 
        return (!(ospaceEntityType.Abstract ||
                    ospaceEntityType.ClrType.IsSealed ||
                    typeof(IEntityWithRelationships).IsAssignableFrom(ospaceEntityType.ClrType) ||
                    !accessableCtor) &&
                    access == TypeAttributes.Public);
    }
