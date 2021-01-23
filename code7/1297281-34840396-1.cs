            container.Register(Component.For(typeof(IDataProvider<>))
                .Forward(typeof(IReadOnlyDataProvider<>))
                .UsingFactoryMethod((kernel, model, creationContext) =>
                {
                    var type = creationContext.GenericArguments.First();
                    if (type.GetInterface("ISqlDbEntity") != null)
                    {
                        var sqlProvider = typeof(SqlDataProvider<>);
                        return Activator.CreateInstance(sqlProvider.MakeGenericType(type), kernel.Resolve<DbContext>());
                    }
                    var mongoProvider = typeof(MongoDataProvider<>);
                    return Activator.CreateInstance(mongoProvider.MakeGenericType(type), kernel.Resolve<MongoClientSettings>(), ConfigurationManager.AppSettings["MongoDatabaseName"]);
                })
                .IsDefault()
                .LifestylePerWebRequest());
