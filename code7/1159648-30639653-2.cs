            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("url"));
            tfs.EnsureAuthenticated();
 
            IGroupSecurityService gss = tfs.GetService<IGroupSecurityService>();
 
            Identity SIDS = gss.ReadIdentity(SearchFactor.AccountName, "Project Collection Valid Users", QueryMembership.Expanded);
 
            Identity[] UserId = gss.ReadIdentities(SearchFactor.Sid, SIDS.Members, QueryMembership.None);
 
            foreach (Identity user in UserId)
            {
                Console.WriteLine(user.AccountName);
                Console.WriteLine(user.DisplayName);
            }
