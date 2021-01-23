    void Main()
    {
        var foo = new Foo();
        var result = foo.Combine(2, 2); // 4
    }
    
    public static class Extensions
    {
        public static string Combine(this Foo foo, params int[] values)
        {
            return string.Join(string.Empty, values.Select(x => x.ToString()));
        }
    }
    
    public class Foo
    {
        public int Combine(params int[] values)
        {
            return values.Sum();
        }
    }
