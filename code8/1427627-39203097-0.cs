    public class Repository : IRepository
    {
        // IDbCommander is a Drapper construct.
        private readonly IDbCommander _commander;
        
        public Repository(IDbCommander commander)
        {
            _commander = commander;
        }
        public IEnumerable<A> RetrieveAll()
        {
            // execute the multiple queries and 
            // pass control to a mapping function.
            return _commander.Query(Map.Results);
        }
        private static class Map
        {
            internal static Func<IEnumerable<A>,
                                IEnumerable<B>,
                                IEnumerable<C>,
                                IEnumerable<C>,
                                IEnumerable<A>> Results = (collectionA, collectionB, collectionC, collectionD) => 
            {
                // map C and D to B based on their Id's
                collectionB.C = collectionC.SingleOrDefault(c => c.Id == b.Id);
                collectionB.D = collectionD.SingleOrDefault(d => d.Id == b.Id);
                
                // now map B to A.
                collectionA.B = collectionB.Where(b => b.Id == a.Id).ToList();
                return collectionA;
            }
        }
    }
