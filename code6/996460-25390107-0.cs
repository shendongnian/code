    var specializedContents = new object[] { ... };
    var typeInterfacePairs = specializedContents.Select(o => o.GetType())
        .SelectMany(t => t.GetInterfaces().Select(i => Tuple.Create(t, i)));
    
    // or
    var typeInterfaceObjs = specializedContents.Select(o => o.GetType())
        .SelectMany(t =>
            t.GetInterfaces().Select(i => new { Type = t, Interface = i }));
