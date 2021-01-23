    builder.RegisterType<IMyclass>().As<MyClass>();
    // Since it is possible more than one `IActionFilter` is registered,
    // we are using a named type. You could alternatively create another 
    // interface to uniquely identify this action filter.
    builder.RegisterType<IActionFilter>()
           .Named<Action1DebugActionWebApiFilter>("action1DebugActionWebApiFilter");
