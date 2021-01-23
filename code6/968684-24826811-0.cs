        private static string GetUrlByGuid(Guid guid, SPAuditItemType type, string location)
        {
            switch (type)
            {
                case SPAuditItemType.Site:
                    return SPContext.Current.Site.Url;
                case SPAuditItemType.Web:
                    try
                    {
                        using (var site = new SPSite(SPContext.Current.Site.ID))
                        using (var web = site.OpenWeb(guid))
                        {
                            return web.Url;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        return string.Empty;
                    }
                case SPAuditItemType.List:
                {
                    if (string.IsNullOrEmpty(location))
                        throw new ArgumentNullException("location");
                    using (var site = new SPSite(SPContext.Current.Site.Url + "/" + location))
                    {
                        using (var web = site.OpenWeb())
                        {
                            try
                            {
                                return web.Lists[guid].DefaultViewUrl;
                            }
                            catch (SPException)
                            {
                                return string.Empty;
                            }
                        }
                    }
                }
                case SPAuditItemType.ListItem:
                    var match = ListItemRegex.Match(location);
                    string listUrl = match.Groups[1].Value.Trim('/');
                    using (var site = new SPSite(SPContext.Current.Site.Url + "/" + location))
                    using (var web = site.OpenWeb()) 
                    {
                        foreach (SPList list in web.Lists)
                        {
                            if (list.RootFolder.ServerRelativeUrl.Trim('/') == listUrl)
                            {
                                return string.Format("{0}?ID={1}",
                                    SPUtility.ConcatUrls(web.Url, list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url),
                                    match.Groups[2].Value);
                            }
                        }
                    }
                    return string.Empty;
                case SPAuditItemType.Document:
                    return SPContext.Current.Site.Url + "/" + location;
                default:
                    return string.Empty;
            }
        }
        private static readonly Regex ListItemRegex = new Regex(@"(.+?)(\d+)_.000", RegexOptions.Compiled);
