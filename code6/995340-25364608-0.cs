    var originalUrl = HttpContext.Current.Request.Url;
    var allAliases = Sitecore.Context.Database.SelectItems("/sitecore/system/aliases//*");
    var foundAlias = allAliases.FirstOrDefault( alias =>
                            !string.IsNullOrEmpty(alias["Regular Expressions"]) &&
                            Regex.IsMatch(HttpContext.Current.Request.Url.ToString(), alias["Regular Expressions"]));
