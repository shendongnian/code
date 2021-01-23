    var mvc = services.AddMvc(options =>
    {
       //mvc options
    });
    
    mvc.AddJsonOptions(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
