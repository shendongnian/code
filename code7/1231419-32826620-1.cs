    static void LateBound(string server) {
        var catt = Type.GetTypeFromProgID("COMAdmin.COMAdminCatalog");
        dynamic cat = Activator.CreateInstance(catt);
        cat.Connect(server);
        dynamic coll = cat.GetCollection("Applications");
        coll.Populate();
        foreach (dynamic app in coll) {
            Console.WriteLine(app.Name);
            dynamic comps = coll.GetCollection("Components", app.Key);
            comps.Populate();
            foreach (dynamic comp in comps) {
                Console.WriteLine("  {0} - {1}", comp.Name, comp.Key);
            }
        }
    }
