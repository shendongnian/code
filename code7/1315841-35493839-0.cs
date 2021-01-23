    public class SomeClass
    {
        private IMyThing _thing;
    
        public bool HasThing(IEnumerable<IMyThing> things, IEqualityComparer<IMyThing> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<IMyThing>.Default;
            return things.Contains(_thing, comparer);
        }
    }
