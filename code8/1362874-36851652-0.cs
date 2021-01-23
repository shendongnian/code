    void Main()
    {
    	var container = new WindsorContainer();
    	container.Install(new Installer());
    	
    	var car = container.Resolve<Car>();
    	car.Dump();
    }
    
    public class Service
    {
    	private ICar<CarEntity> _car;
    
    	public Service(ICar<CarEntity> car)
    	{
    		_car = car;
    	}
    }
    
    public class TEntity { }
    public class CarEntity : TEntity { }
    public class BoatEntity : TEntity { }
    
    public interface ICreatable { }
    public interface ICar<TEntity> : ICreatable { }
    
    public class Car : ICar<TEntity> 
    {
    	private ConnectionDetails _connectionDetails;
    	
    	public Car(ConnectionDetails connectionDetails)
    	{
    		_connectionDetails = connectionDetails;	
    		Initialize();
    	}
    
    	public void Initialize() {}
    }
    
    public class ConnectionDetails { }
    
    public class Installer : IWindsorInstaller
    {
    	public void Install(IWindsorContainer container, IConfigurationStore store)
    	{
    		container.Register(
                Component.For<ConnectionDetails>()
                         .ImplementedBy<ConnectionDetails>());
    	
    		container.Register(
    			Classes.FromAssemblyInThisApplication()
    				.BasedOn(typeof(ICreatable))
    				.WithServiceAllInterfaces()
    				.WithServiceSelf()
    				.LifestyleTransient());
    	}
    }
