    var container = new Container(x =>
        {
            x.Scan(y =>
                {
                    y.AssemblyContainingType(typeof(ICommandHandler<>));
                    y.Exclude(t => t == typeof(Decorator1<>));
                    y.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                });
            x.For(typeof(ICommandHandler<>)).DecorateAllWith(typeof(Decorator1<>));
        });
