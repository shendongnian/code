    static void EarlyBound(string server) {
        var cat = new COMAdmin.COMAdminCatalog();
        cat.Connect(server);
        var coll = (COMAdmin.COMAdminCatalogCollection)cat.GetCollection("Applications");
        coll.Populate();
        foreach (COMAdmin.ICatalogObject app in coll) {
            Console.WriteLine(app.Name);
            var comps = coll.GetCollection("Components", app.Key);
            comps.Populate();
            foreach (COMAdmin.ICatalogObject comp in comps) {
                Console.WriteLine("  {0} - {1}", comp.Name, comp.Key);
            }
        }
    }
