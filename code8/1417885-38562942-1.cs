    public class Foo
    {
        private readonly IDictionary<string,int> lastcalled = new Dictionary<string,int>();
    
        public void RegisterCallOf( string name )
        { 
            int now = Environment.TickCount;
            if ( lastcalled.ContainsKey( name ) )
                lastcalled[name] = now;
            else
                lastcalled.Add( name, now );
        }
    
        public bool WasCalledDuringLast( string name, int milliseconds )
        {
            int now = Environment.TickCount;
            if ( lastcalled.ContainsKey( name ) )
              return now - lastcalled[name] <= milliseconds;
            return false; 
        }
    }
