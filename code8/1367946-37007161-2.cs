    using System;
    using Autofac;
    
    namespace DemoApp
    {
      public class Program
      {
        private static IContainer Container { get; set; }
    
        static void Main(string[] args)
        {
          var builder = new ContainerBuilder();
          // register your base class
          builder.RegisterType<BaseClass>() // register base class
                 .AsSelf()                  // register as `BaseClass` (without any interfaces)
                 .SingleInstance();         // register as a singleton
    
          // register all your child classes
          builder.RegisterType<FirstClass>()
                 .AsSelf()                  
                 .SingleInstance();
          builder.RegisterType<SecondClass>()
                 .AsSelf()                  
                 .SingleInstance();
    
          // or you can do the following
          // get the assembly
          var dataAccess = Assembly.GetExecutingAssembly();
    
          // and register all classes which ends with 'Settings' as singletons
    	  builder.RegisterAssemblyTypes(dataAccess)
    	         .Where(t => t.Name.EndsWith("Settings"))
    	         .AsSelf()
                 .SingleInstance();   
    
          Container = builder.Build();
    
          // The DoWorkmethod is where we'll make use
          // of our dependency injection.
          DoWork();
        }
    
        public static void WriteDate()
        {
            // Create the scope, resolve your FirstClass,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var firstClass = scope.Resolve<FirstClass>();
                firstClass.SomeMethodOrWhatever();
            }
        }
      }
    }
