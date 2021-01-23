static System.Guid[] GetGroupMemberGuids(System.DirectoryServices.AccountManagement.GroupPrincipal group)
{
    System.Collections.Generic.List<System.Guid> result = new List<Guid>();
    if (group == null) return null;
    System.DirectoryServices.AccountManagement.PrincipalCollection px = group.Members;
    System.Collections.IEnumerator en = px.GetEnumerator();
    bool hasMore = true;
    int consecFaults = 0;
    while (hasMore && consecFaults < 10)
    {
        System.DirectoryServices.AccountManagement.Principal csr = null;
        try
        {
            hasMore = en.MoveNext();
            if (!hasMore) break;
            csr = (System.DirectoryServices.AccountManagement.Principal)en.Current;
            consecFaults = 0;
        }
        catch (System.DirectoryServices.AccountManagement.PrincipalOperationException e)
        {
            Console.Error.WriteLine("    Unable to enumerate a member due to the following error: {0}", e.Message);
            consecFaults++;
            csr = null;
        }
        if (csr is System.DirectoryServices.AccountManagement.UserPrincipal)
            result.Add(csr.Guid.Value);
    }
    if (consecFaults >= 10) throw new InvalidOperationException("Too many consecutive errors on retrieval.");
    return result.ToArray();
}
