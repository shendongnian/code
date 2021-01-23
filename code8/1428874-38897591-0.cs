    container.Register(Component
                   .For<MyDatabaseContext>().Forward<DbContext>()
                   .ImplementedBy<MyDatabaseContext>()
                   .LifestylePerWebRequest()
                   .UsingFactoryMethod(context =>
                   {
                     return MyDatabaseContextFactory.Create(HttpContext.Current.Request.Url);
                   }));
