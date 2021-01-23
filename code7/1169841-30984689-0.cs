    public class ClassArg1 { }
    public class ClassArg2 { }
    public class ClassTarget
    {
      // Create a delegate factory with the set of parameters you require
      // during the Resolve operation - things that won't be auto-filled by Autofac.
      public delegate ClassTarget Factory(ClassArg2 arg2);
      // The constructor can have all the required parameters. Make sure the
      // names here match the names in the delegate factory.
      public ClassTarget(ClassArg1 arg1, ClassArg2 arg2)  { }
      // Just something to show the initalization working.
      public bool IsInitialized { get; set; }
    }
    public static class ResolveFuncTest
    {
      public static void Initialize(ClassTarget target)
      {
        // Instead of newing up the ClassTarget here, let Autofac do that
        // through the delegate factory and *only* do initialization here -
        // the "something fancier" you previously alluded to.
        target.IsInitialized = true;
      }
      public static void Test()
      {
        // Register the argument that gets populated by Autofac.
        var builder = new ContainerBuilder();
        builder.RegisterType<ClassArg1>().AsSelf().SingleInstance();
        // Register the ClassTarget and Autofac will see the factory delegate.
        builder.RegisterType<ClassTarget>().OnActivated(args => Initialize(args.Instance));
        var context = builder.Build();
        using(var scope = context.BeginLifetimeScope())
        {
          // Resolve a factory delegate rather than resolving the class directly.
          var factory = scope.Resolve<ClassTarget.Factory>();
          var classTarget = factory(new ClassArg2());
          // Do whatever you need.
          Console.WriteLine("ClassTarget is initialized? {0}", classTarget.IsInitialized);
        }
      }
    }
