    // -------------------------------------------------------------------------------------------------------------
    // This is the "uber" GetType() that all public GetType() funnels through. It's main job is to figure out which
    // Assembly to load the type from and then invoke GetTypeHaveAssembly.
    //
    // It's got a highly baroque interface partly for historical reasons and partly because it's the uber-function
    // for all of the possible GetTypes.
    // -------------------------------------------------------------------------------------------------------------
    /* private instance */ TypeHandle TypeName::GetTypeWorker
    
