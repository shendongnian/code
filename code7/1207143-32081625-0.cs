    class Program
    {
        static void Main(string[] args)
        {
            var source = new List<object> {
                "foo",
                "bar",
                "baz"
            };
            var type = typeof(string); // or however you find out the type
            var castMethod = typeof(Enumerable)
                .GetMethod("Cast").MakeGenericMethod(
                new[] {
                    type
                });
            var result = (IEnumerable<string>)
                castMethod.Invoke(null, new object[] {source});
            foreach (var str in result)
            {
                Console.WriteLine(str.ToUpper());
            }
        }
    }
