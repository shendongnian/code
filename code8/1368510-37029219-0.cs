    var builder = new ContainerBuilder();
    builder
        .Register<Func<bool, IRunHistoryRepository>>(
            x =>
            {
                var context = x.Resolve<IComponentContext>();
                return isUserInRole => 
                {
                    return isUserInRole
                        ? context.Resolve<RunHistoryRepository>()
                        : context.Resolve<DifferentRunHistoryRepository>();
                }
            }
    )};
