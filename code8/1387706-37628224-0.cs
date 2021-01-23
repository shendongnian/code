    public interface ILogger
    {
    	void Log(LogEntry entry);
    }
    
    public class SerilogLogger<T> : ILogger
    {
    	private readonly Serilog.ILogger _logger;
    
    	public SerilogLogger()
    	{
    		_logger = new LoggerConfiguration()
    			.WriteTo
    			.Trace(LogEventLevel.Information)
    			.CreateLogger()
    			.ForContext(typeof (T));
    	}
    
    	public void Log(LogEntry entry)
    	{
    		/* Logging abstraction handling */
    	}
    }
    public static class ContainerExtensions {
    
    	public static void RegisterLogging(this Container container)
    	{
    		container.RegisterConditional(
    			typeof(ILogger),
    			c => typeof(SerilogLogger<>).MakeGenericType(c.Consumer.ImplementationType),
    			Lifestyle.Transient,
    			c => true);
    	}
    	
    }
