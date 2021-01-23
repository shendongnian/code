    // MyProject.Data.EF.csproj
    // This project uses EF to implement that data
    namespace MyProject.Data.EF
    {
      // internal, because I don't want anyone to actually create this class
      internal class PersonRepository : IPersonRepository
      {
        Person Get()
        {  // implementation  }
      }
      public class Registration : Autofac.Module
      {
        protected override void Load(ContainerBuilder builder)
        {
          builder.Register<PersonRepository>()
            .As<IPersonRepository>()
            .IntancePerLifetimeScope();
        }
      }
    }
