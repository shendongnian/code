    container.Options.RegisterResolveInterceptor((context, producer) => {
            var watch = Stopwatch.StartNew();
            try {
                return producer();
            } finally {
                watch.Stop();
                if (watch.ElapsedMilliseconds > 50) {
                    Console.WriteLine(
                        "Resolving {0} took {1} ms. Object graph: {2}",
                        context.Producer.ServiceType.Name,
                        watch.ElapsedMilliseconds,
                        context.Producer.VisualizeObjectGraph());
                }
            }
        },
        // Apply to every registration
        context => true);
