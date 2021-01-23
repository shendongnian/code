    public static List<string> GetAllUserNames(string domain = null) {
        List<string> userNames = new List<string>();
        using (var principalContext = createPrincipalContext(domain)) {
            //Get a list of user names in MyDomain that match filter
            using (UserPrincipal userPrincipal = new UserPrincipal(principalContext)) {
                using (PrincipalSearcher principalSearcher = new PrincipalSearcher(userPrincipal)) {
                    var results = principalSearcher
                        .FindAll()
                        .Where(c =>
                            (c is UserPrincipal) &&
                            (c as UserPrincipal).Enabled.GetValueOrDefault(false) &&
                            !string.IsNullOrEmpty(c.DisplayName)
                            );
                    foreach (UserPrincipal p in results) {
                        var temp = p.StructuralObjectClass;
                        string value = string.Format("{0} ({1})", p.DisplayName, p.EmailAddress ?? Join("\\", p.Context.Name, p.SamAccountName));
                        userNames.Add(value);
                    }
                }
            }
        }
        return userNames;
    }
