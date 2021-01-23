	public class ContainerConfig
	{
		public static IContainer RegisterContainer() 
		{
			//Create a new ContainerBuilder
			var builder = new ContainerBuilder();
			// Register all the controllers using the assembly object
			builder.RegisterControllers(Assembly.GetExecutingAssembly());
			//Registering default convention -- IExample and Example
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				  .Where(t => t.Name.Single(i => i.Name == "I" + t.Name))
				  .AsImplementedInterfaces();
			// Register our filter
			builder.RegisterType<GetUserActionFilter>()
			   .Named<IActionFilter>("getUserActionFilter");
				  
			//Build the container
			var container = builder.Build();
			//Set the default resolver to use Autofac
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
			
			// Return the container to our composition root.
			return container;
		}
	}
