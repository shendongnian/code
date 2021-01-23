    // What I want is the allSites array but with the terminals filtered.
    List<Site> toReturn = new List<Site>(allSites);
    foreach (Site s in toReturn)
    {
        // Look through every Terminal
        // And check if they have any UserAccess that would allow access.
        // If no access (!t.AccessList.Any), remove this Terminal.
        s.Terminals.RemoveAll(t => !t.AccessList.Any(
            a => a.user.Name.Equals("Ian")));
    }
    // Also if I want empty Sites removed:
    toReturn.RemoveAll(s => !s.Terminals.Any());
