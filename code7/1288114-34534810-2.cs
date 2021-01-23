    var namesAndValues = 
        controllers.SelectMany(controller =>
            controller.Actions.Select(action =>
                { 
                  Name = controller.Name + "." + action.Name,
                  HttpCache = action.HttpCache
                }));
    var dict = namesAndValues.ToDictionary(nav => nav.Name, nav => nav.HttpCache); 
