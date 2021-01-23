    public class LoggerFactory {
       
       public ILogger Create( string context ) {
          if ( !string.IsNullOrEmpty( context ) )
             return new ContextAwareLogger( context, new ConcreteLogger() );
          else
             return new ConcreteLogger();
       }
    }
