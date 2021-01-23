    string @namespace = "MyApp.Areas.Admin.Controllers";
    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == @namespace 
            && typeof(t).IsSubclassOf(typeof(Controller))
            select t;
