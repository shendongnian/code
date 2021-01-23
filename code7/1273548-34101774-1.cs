            // Consumers of this don't need to know anything more than it's an IHandler service
    // Consumers of this don't need to know anything more than it's an IHandler service
    IHandler noregistrationHandlers = new Assessment(new Enrollment(null));
    // or Autofac
    // builder.Register(c => new Assessment(c.Resolve<Enrollment>(null))).Named("NoRegistration");
    // or your favorite IoC container
    noregistrationHandlers.Handle("Smith");
    IHandler registrationHandlers = new Registration(new Assessment(new Enrollment(null)));
    // builder.Register(c => new Registration(c.Resolve<Assessment>(c.Resolve<Enrollment>(null)))).Named("Registration");
    registrationHandlers.Handle("Bob");
