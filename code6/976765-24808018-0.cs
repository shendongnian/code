    IList<Site> listA = ...
    IList<Site> listB = ...
    var keysA = new HashSet<Tuple<string,int>>(
        listA.Select(site => Tuple.Create(site.Type, site.Index))
    );
    foreach (var site in listB) {
        var keyB = Tuple.Create(site.Type, site.Index);
        if (keysA.Contains(keyB)) {
            // site is in both lists
        } else {
            // site is in listB but not listA
        }
    }
