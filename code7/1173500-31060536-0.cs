        static void Main(string[] args)
        {
            var printout = new string[] { "Type a lowercase letter.", "OK. Type another lowercase letter", "Error" };
            Console.WriteLine(printout[0]);
            foreach (var item in GenerateSequance(() => Console.ReadLine()[0], x => x != '!'))
            {
                Console.WriteLine(printout[char.IsLower(item) ? 1 : 2]);
            }
        }
        public static IEnumerable<T> GenerateSequance<T>(Func<T> generator, Predicate<T> predicat)
        {
            var curr = generator();
            if (!predicat(curr))
            {
                yield break;
            }
            yield return curr;
        }
