    public static class SPListItemContextIsolatedExtension 
    {
        public static SPListItem Isolate(SPListItem item)
        {
            var site = new SPSite(item.ParentList.ParentWeb.Url);
            var web = site.OpenWeb();
            return web.GetListItem(item.Url);
        }
        public static void RunIsolated(this SPListItem item, Action<SPListItem> act)
        {
            Task.Factory.StartNew(() => act(item.Isolate()));
        }
    }
