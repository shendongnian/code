    public class Range<T> 
    {
        Range() { }
        Range( T bound1, T bound2 ) { /* your static method logic here */ }
    }
    
    public class IntRange : Range<int>
    {
        IntRange( int bound1, int bound2 ) 
            : base( bound1, bound2 )
        { }
    
        IntRange( int b1, int b2, bool someExampleFlag )
        {
            // custom logic here
        }
    }
