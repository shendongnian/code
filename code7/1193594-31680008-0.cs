    public static IApplicationBuilder UseAutofac( [NotNull] this IApplicationBuilder applicationBuilder )
    {
        IAutofacResolver autofacResolver = applicationBuilder.GetService<IAutofacResolver>();
        ILibraryManager libraryManager = applicationBuilder.GetService<ILibraryManager>();
        autofacResolver.RegisterLibraryModules( libraryManager);
        applicationBuilder.ApplicationServices = autofacResolver.Resolve();
        return applicationBuilder;
    }
