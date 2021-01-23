        public class Comparer : IEqualityComparer<YourClass>
        {
            public bool Equals(YourClass x, YourClass y)
            {
                // Your implementation
            }
    
            public int GetHashCode(YourClass obj)
            {
                // Your implementation
            }
        }
    
        var collection1 = baseCollection.Where(r => filterCollection.Contains(r.Property));
        var collection2 = baseCollection.Except(collection1, new Comparer());
