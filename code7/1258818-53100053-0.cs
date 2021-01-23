    public class ServiceModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<AutoFac.AsyncRunner>().As<AutoFac.IAsyncRunner>().SingleInstance();
        }
    }
    public class Controller
    {
    private AutoFac.IAsyncRunner _asyncRunner;
    
    public Controller(AutoFac.IAsyncRunner asyncRunner)
    {
    	
    	_asyncRunner = asyncRunner;
    }
    
    public void Function()
    {
    	_asyncRunner.Run<IService>((cis) =>
       {
    	   try
    	   {
    		  //do stuff
    	   }
    	   catch
    	   {
    		   // catch stuff
    		   throw;
    	   }
       });
    }
    }
