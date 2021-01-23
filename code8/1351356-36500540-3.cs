      using System.Reflection;
      using Autofac;
      using DataAccessLayer;
      using Module = Autofac.Module;
     public class BusinessLayerModule : Module
      {
         protected override void Load(ContainerBuilder builder)
          {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces(); // that links all clases with the implemented interfaces (it they mapped 1:1 to each other)
          }
