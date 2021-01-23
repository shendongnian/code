    using (var container = new WindsorContainer())
    {
    	container.AddFacility<TypedFactoryFacility>();
    
    	container.Register(
    		Component.For<IBoo>().ImplementedBy<Boo>().LifestyleTransient(),
    		Component.For<IBar>().ImplementedBy<Bar>().LifestyleTransient(),
    
    		Types.FromThisAssembly()
    			.Where(c => c.Namespace == "MyFactories" && c.Name.EndsWith("Factory"))
    			.Configure(c=>c.AsFactory())
    		);
    
    	var booFactory = container.Resolve<IBooFactory>();
    	var boo = booFactory.Create();
    	Console.WriteLine(boo.GetType().FullName);
    	booFactory.FreeUp(boo);
    
    	var barFactory = container.Resolve<IBarFactory>();
    	var bar = barFactory.Create();
    	Console.WriteLine(bar.GetType().FullName);
    	barFactory.FreeUp(bar);
    }	
  
    namespace MyFactories
    {
    	public interface IBooFactory
    	{
    		IBoo Create();
    		void FreeUp(IBoo cmp);
    	}
    
    	public interface IBarFactory
    	{
    		IBar Create();
    		void FreeUp(IBar cmp);
    	}
    
    	public interface IBar{}
    
    	public interface IBoo{}
    
    	public class Boo : IBoo{}
    
    	public class Bar : IBar{}
    
    }
