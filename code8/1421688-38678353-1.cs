        _someDI.Get<ICourseRepository>(new Parameter(_context));
    You'll need to register your types first like this:
        _someDI.Register<ICourseRepository, CourseRepository>();
    or all types together:
        _someDI.RegisterAllImplementingInterface<IBaseRepository>().AsImplementingInterfaces();
    It'll also make using single method possible, though types will be less discoverable:
        TRep GetRepository<TRep>() where TRep : IBaseRepository =>
            _someDI.Get<TRep>(new Parameter(_context));
