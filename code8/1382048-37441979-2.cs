    var clientContext = new ClientContext("http://theoracle/")
        { AuthenticationMode = ClientAuthenticationMode.Default};
    var taxonomySession = TaxonomySession.GetTaxonomySession(clientContext);
    var termStore = taxonomySession.GetDefaultSiteCollectionTermStore();
    clientContext.Load(termStore,
            store => store.Name,
            store => store.Groups.Include(
                group => group.Name,
                group => group.TermSets.Include(
                    termSet => termSet.Name,
                    termSet => termSet.Terms.Include(
                        term => term.Name)
                )
            )
    );
    clientContext.ExecuteQuery();
    if (taxonomySession != null)
    {
        if (termStore != null)
        {
            foreach (var termGroup in termStore.Groups)
            {
                foreach (var termSet in termGroup.TermSets)
                {
                    foreach (var term in termSet.Terms)
                    {
                        MessageBox.Show(term.Name);
                    }
                }
            }
        }
    }
