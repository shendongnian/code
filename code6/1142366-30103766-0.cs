    // Users u - will serve as an alias source below
    Users u = null;
    IList<Users> users = this.Session.QueryOver<Users>()
            .Where(f => f.role == role)
            .SelectList(list => list        // here we set the alias 
                    .Select(p => p.username) .WithAlias(() => u.username)
                    .Select(p => p.email)    .WithAlias(() => u.email)
                    .Select(p => p.firstname).WithAlias(() => u.firstname)
            )
            // here we Transform result with the aliases into Users
            .TransformUsing(Transformers.AliasToBean<Users>())
            .List<Users>();
