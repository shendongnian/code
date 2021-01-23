    public void YourMethod()
    {
        ...
        var instancePrivate = currentType.FindMembers(MemberTypes.Property,
                                                      BindingFlags.Instance |
                                                      BindingFlags.NonPublic,
                                                      PrivateMemberFilter, null);
            .OfType<PropertyInfo>();
        ...
    }
    static readonly MemberFilter PrivatePropertyFilter = (objMemberInfo, objSearch) =>
    {
        PropertyInfo info = (objMemberInfo as PropertyInfo);
        if (info == null)
        {
            return false;
        }
        return info.GetMethod.IsPrivate && info.SetMethod.IsPrivate;
    };
