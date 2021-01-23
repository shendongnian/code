        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.FileProvider = new CompositeFileProvider(
                new EmbeddedFileProvider(
                    typeof(BooksController).GetTypeInfo().Assembly,
                    "BookStore.Portal" // your external assembly's base namespace
                ),
                options.FileProvider
            );
        });
