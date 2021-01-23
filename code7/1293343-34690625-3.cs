    var sites1 = Sitecore.Configuration.Settings.Sites
            .Select(x => new {DisplayName = x.StartItem.TrimStart('/'), Language = x.Language});
    var siteNames = new HashSet<string>(sites1.Select(x=> x.DisplayName.ToLower());
    var items1 = Sitecore.Context.Database.SelectItems(query)
            .Where(x=>siteNames.Any(it=>it == x.DisplayName.ToLower()))
            .ToList();
