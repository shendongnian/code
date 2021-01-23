     public abstract class Startup
     {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
           var builder = new ContainerBuilder();
           builder.Populate(services);
           // Update existing container
           builder.Update(Program.Container);
        }
     }
