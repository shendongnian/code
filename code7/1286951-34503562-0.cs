    using System.Diagnostics;
    using System.Threading;
    ...
    public static Int32 Main(String[] args) {
        if( !Debugger.IsAttached ) {
            Console.WriteLine("No debugger attached. Execution will resume once a debugger is attached.");
            while( !Debugger.IsAttached ) Thread.Sleep( 100 );
        }
    }
    
