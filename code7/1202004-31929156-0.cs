    public class MyCustomStringComparer : IComparer<string>
    {
        private readonly StringComparer    baseComparer    ;
        private readonly StringComparison? comparisonStyle ;
        public MyCustomStringComparer( StringComparer baseComparer ) : this( baseComparer , null )
        {
        }
        public MyCustomStringComparer( StringComparison comparisonStyle ) : this( null , comparisonStyle )
        {
        }
        public MyCustomStringComparer() : this( null , null )
        {
        }
        private MyCustomStringComparer( StringComparer comparer , StringComparison? style )
        {
            this.baseComparer = comparer ;
            this.comparisonStyle = style ;
        }
        public int Compare( string x , string y )
        {
            if      ( x == null && y == null ) return  0 ; // two nulls are equal
            else if ( x == null && y != null ) return +1 ; // null is greater than non-null
            else if ( x != null && y == null ) return -1 ; // non-null is less than null
            else // ( x != null && y != null ) ;
            {
                if      ( baseComparer    != null ) return baseComparer.Compare(x,y);
                else if ( comparisonStyle != null ) return string.Compare(x,y,comparisonStyle.Value);
                else                                return x.CompareTo(y);
            }
        }
    }
