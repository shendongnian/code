    var MemberQuery = (from SystemUser 
        in SecurityFilter.FilteredMembers(SecurityInfo, Context, DetailLevelEnum.NameOnly)
    join Member in Context.webpages_Memberships on SystemUser.ID 
        equals Member.UserId
    join _UserRole in Context.webpages_UsersInRoles on Member.UserId 
        equals UserRole.UserId as _UserRole
    from UserRole in _UserRole.DefaultIfEmpty()
    where (Member.IsConfirmed || IncludeUnconfirmed )
    && (
        Filter.SelectedMemberRoles == null || UserRole != null 
        && Filter.SelectedMemberRoles.Contains(UserRole.RoleId)
    )
    select SystemUser)
    .Distinct();
