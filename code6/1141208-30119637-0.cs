If you want to use Principals instead of DirectorySearcher you can call GetUnderlyingObject() on the UserPrincipal object and get the DirectoryEntry for it.
    using(var user = new UserPrincipal(domainContext))
    {
        DirectoryEntry dEntry = (DirectoryEntry)user.GetUnderlyingObject();
        Object manager = dEntry.Properties["manager"][0];
    }
