        static void Main(string[] args)
        {
            var printout = new string[] { "Type a lowercase letter.", "OK. Type another lowercase letter", "Error" };
            Console.WriteLine(printout[0]);
            foreach (var item in SequenceGenerator(() => Console.ReadLine()[0]).TakeWhile(x => x != '!'))
            {
                Console.WriteLine(printout[char.IsLower(item) ? 1 : 2]);
            }
        }
        public static IEnumerable<T> SequenceGenerator<T>(Func<T> generator)
        {
            while (true)
            {
                yield return generator();;
            }
        }
