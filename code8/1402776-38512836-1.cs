    public static class SPListItemContextIsolatedExtension 
    {
        public static SPListItem Isolate(SPListItem item)
        {
            var parentWeb = item.ParentList.ParentWeb.Url;
            var site = new SPSite(parentWeb);
            var web = site.OpenWeb();
            return web.GetListItem($"{parentWeb}/{item.Url}");
        }
        public static void RunIsolated(this SPListItem item, Action<SPListItem> act)
        {
            Task.Factory.StartNew(() => act(item.Isolate()));
        }
    }
