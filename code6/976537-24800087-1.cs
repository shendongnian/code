      private static void RegisterServices(IKernel kernel)
        {
          //kernel.Bind<IUserRepository>().To<UserRepository>();
          kernel.Bind<IPostRepository>().To<PostRepository>();
        }
