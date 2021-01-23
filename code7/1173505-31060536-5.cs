        static void Main(string[] args)
        {
            var printout = new string[] { "Type a lowercase letter.", "OK. Type another lowercase letter", "Error" };
            Console.WriteLine(printout[0]);
            var sequance = SequenceOf(() => (Console.ReadLine() + " ")[0])
                .TakeWhile(x => x != '!');
            foreach (var item in sequance)
            {
                Console.WriteLine(printout[char.IsLower(item) ? 1 : 2]);
            }
        }
        public static IEnumerable<T> SequenceOf<T>(Func<T> generator)
        {
            while (true)
            {
                yield return generator();
            }
        }
