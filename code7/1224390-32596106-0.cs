    builder.RegisterType<SubSystem>()
      .InstancePerOwned<SubSystem>();
    builder.RegisterType<SubSystemGraph>()
      .As<ISubSystem>()
      // Appropriate sharing here...
      ;
