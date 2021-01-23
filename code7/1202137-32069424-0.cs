    public override void Execute(Guid contentDbId)
        {
            var webApplication = Parent as SPWebApplication;
            if (webApplication == null) return;
            using (var site = webApplication.ContentDatabases[contentDbId].Sites[0])
            {
                var web = site.RootWeb;
                ...
            }
         }
