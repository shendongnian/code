     public class Foo
        {
            public static bool operator ==(Foo a, Foo b)
            {
                if (System.Object.ReferenceEquals(a, b))
                {
                    return true;
                }
                if (((object)a == null) || ((object)b == null))
                {
                    return false;
                }
                return a == b;
            }
    
            public static bool operator !=(Foo a, Foo b)
            {
                return !(a == b);
            }
        }
