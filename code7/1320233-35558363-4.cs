    public class UniqueIDsOnFooCommand : ISpecimenCommand
    {
        private static readonly int[] languageIds = new [] { 1, 2, 666, };
        private static readonly Random random = new Random();
    
        public void Execute(object specimen, ISpecimenContext context)
        {
            var foo = specimen as Foo;
            if (foo == null)
                return;
    
            foreach (var t in
                foo.Descriptions.Zip(Shuffle(languageIds), Tuple.Create))
            {
                var description = t.Item1;
                var id = t.Item2;
                description.LanguageId = id;
            }            
        }
    
        private static IEnumerable<T> Shuffle<T>(IReadOnlyCollection<T> source)
        {
            return source.OrderBy(_ => random.Next());
        }
    }
