    _context = new PrincipalContext(ContextType.Domain);
    public async Task<IEnumerable<UserModel>> SearchDisplayNameAsync(string searchPhrase, bool enabled = true)
    {
        IEnumerable<UserModel> results = await Task.Run(() => SearchDisplayName(searchPhrase: searchPhrase, enabled: enabled));
        return results.ToList();  // <-- ToList() removes nested type
    }
    public IEnumerable<UserModel> SearchDisplayName(string searchPhrase, bool enabled = true)
    {
        UserPrincipal userPrincipal = new UserPrincipal(_context)
        {
            DisplayName = $"{searchPhrase}*",
            Enabled = enabled
        };
        using (PrincipalSearcher searcher = new PrincipalSearcher(userPrincipal))
        {
            return searcher.FindAll()
                .OfType<UserPrincipal>()
                .Select(u => new UserModel
                {
                    Guid = (Guid)u.Guid,
                    DisplayName = u.DisplayName,
                    EmailAddress = u.EmailAddress
                });
        }
    }
