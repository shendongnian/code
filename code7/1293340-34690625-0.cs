    var sites1 = Sitecore.Configuration.Settings.Sites
            .Select(x => {DisplayName = x.StartItem.TrimStart('/'), Lanquage = x.Lanuguage));
    var siteNames = new HashSet<string>(sites1.Select(x=> x.DisplayName.ToLower());
    var items1 = Sitecore.Context.Database.SelectItems(query)
            .Where(x=>site1.Any(it=>it == x.DisplayName.ToLower())).ToList();
