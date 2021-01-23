    void Main()
	{	
		var container = new WindsorContainer();
	
		var type = typeof(II);
		container.Register(Classes.FromAssembly(type.Assembly)
			   .Where(Component.IsInNamespace(type.Namespace))
				.WithService.AllInterfaces()
				.LifestyleTransient());
				
		container.Resolve<II>().Dump();
	}
	
	public interface II
	{
	}
	
	public class MyCl : II
	{
	}
