    using( var ctx = new PrincipalContext(ContextType.Domain, "mydomain") )
    {
        var filter = new GroupPrincipal(ctx) { Name = TxtAccName.Text }
        using ( var searcher = new PrincipalSearcher(filter) )
        {
            var groupExist = searcher.FindAll().Any();
        }
    }
