       public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
       {
          builder.RegisterType<YourPlugin.Controllers.
          ProductController>().As<Nop.Web.Controllers.ProductController>();
       }
       public int Order
       {
            get { return 1; }
       }
