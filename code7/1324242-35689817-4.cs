    [Export( typeof( IStatusBarManager ) )]
    internal class StatusBarManager : IStatusBarManager
    {
        public void Display( string msg )
        {
            Console.WriteLine( msg );
        }
    }
 
