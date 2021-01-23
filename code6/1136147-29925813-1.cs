    string path = @"C:\ssisdata\p1.dtsx";
            
    Application app = new Application();
    Package pkg = new Package();
    pkg.Name = "so_29925774";
    DtsEventHandler eh = pkg.EventHandlers.Add("OnError") as DtsEventHandler;
            
    eh.Variables.Add("sSourceObjectId", false, "User", 1);
    app.SaveToXml(path, pkg, null);
