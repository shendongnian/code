    // Once at startup (not required when using an ITemplateManager which knows how to
    // resolve cache_name)
    Engine.Razor.AddTemplate(cache_name, razorTemplate)
    // On startup
    Engine.Razor.Compile(
        cache_name, 
        typeof(MyModel) /* or model.GetType() or null for 'dynamic'*/
    )
    // instead of the Razor.Parse call
    var result = Engine.Razor.Run(
        cache_name,
        typeof(MyModel), /* or model.GetType() or null for 'dynamic'*/
        model
    )
