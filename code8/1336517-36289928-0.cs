    using (var userPrincipal = UserPrincipal.FindByIdentity(Context, samsAccount))
    {
    var user = (DirectoryEntry) userPrincipal.GetUnderlyingObject();
    DirectoryEntry adEntry = new DirectoryEntry(user.Path, "serviceUser", "Password");
    var newPrimaryGroupId = 1;
    user.Invoke("Put", new object[] { "primaryGroupID", newPrimaryGroupId });
    user.CommitChanges();
    }
