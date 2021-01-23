    public static bool ActiveDirectoryGroupMembershipOk(String userid, String groupname)
    {
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userid);
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupname);
        return user.IsMemberOf(group);
    }
