    void Main()
    {
        var foo = new Foo();
        var result = foo.Combine(2, 2); // "22"
    }
    
    public static class Extensions // added by client
    {
        public static string Combine(this Foo foo, params int[] values)
        {
            return string.Join(string.Empty, values.Select(x => x.ToString()));
        }
    }
    
    public class Foo { }
