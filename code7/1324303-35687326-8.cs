    // Sample class with a name and involvement:
    public class Detail
    {
        public string Name { get; set; }
        public string Involvement { get; set; }
    
        public Detail( string name, string involvement )
        {
            Name = name;
            Involvement = involvement;
        }
    }
    
    // implementation of IComparer that uses a custom alpha sort:
    public class DetailComparer : IComparer<Detail>
    {
        static readonly List<string> Ordered = new List<string> { "suspect", "witness", "victim" };
        public int Compare( Detail x, Detail y )
        {
            int i = Ordered.FindIndex( str => str.Equals( x.Involvement, StringComparison.OrdinalIgnoreCase ) );
            int j = Ordered.FindIndex( str => str.Equals( y.Involvement, StringComparison.OrdinalIgnoreCase ) );
    
            if( i > j ) return 1;
            if( i < j ) return -1;
            return 0;
        }
    }
