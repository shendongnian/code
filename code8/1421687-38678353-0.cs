        _someDI.Get<ICourseRepository>(new Parameter(_context));
    You'll need to register your types first like this:
        _someDI.Register<ICourseRepository, CourseRepository>();
    or all types together:
        _someDI.RegisterAllImplementingInterface<IBaseRepository>().AsImplementingInterfaces();
