    public class Program
    {
        private static void Main(string[] args)
        {
            int[] themes = {1, 2, 3};
            //var a = themes.Select(i => new {f = j => i%2 == 0}); this line gives an error
            var b = themes.Select(i => new {f = new Func<int, bool>(j => i%2 == 0)});
            var c = themes.Select(i => new {f = new MyDelegate(j => i%2 == 0)});
        }
        private delegate bool MyDelegate(int i);
    }
