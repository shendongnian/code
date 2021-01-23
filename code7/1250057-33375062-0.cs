    [Serializable]
    public class OccurrenceCounter<T>
    {
        private Dictionary<T, int> counts;
        public OccurrenceCounter()
        {
            Initialize(default(StreamingContext));
        }
        [OnDeserialized]
        public void Initialize(StreamingContext context)
        {
            if (counts == null)
            {
                counts = new Dictionary<T, int>();
                counts.OnDeserialization(this);
            }
        }
        public int this[T key]
        {
            get 
            {
                if (counts.ContainsKey(key))
                {
                    return counts[key];
                }
                else return 0;
            }
        }
        public bool ContainsKey(T key)
        {
            return counts.ContainsKey(key);
        }
        public int Total()
        {
            return counts.Sum(c => c.Value);
        }
        public int Count()
        {
            return counts.Count;
        }
        public int TotalFor(IEnumerable<T> keys)
        {
            if (keys == null) throw new ArgumentException("Parameter keys must not be null.");
            HashSet<T> hash = keys.ToHashSet();
            return counts.Where(k => hash.Contains(k.Key)).Sum(k => k.Value);
        }
        public void Increment(T key, int amount = 1)
        {
            if (!counts.ContainsKey(key))
            {
                counts.Add(key, amount); // Initialize to zero and increment
            }
            else
            {
                counts[key]+=amount;
            }
        }
        public void Decrement(T key, int amount = 1)
        {
            if (!counts.ContainsKey(key))
            {
                counts.Add(key, -amount); // Initialize to zero and decrement
            }
            else
            {
                counts[key]-=amount;
            }
        }
        /// <summary>
        /// Could not correctly implement IEnumerable on .NET (seems to compile on Mono).  Should be fixed.
        /// See: http://stackoverflow.com/questions/16270722/ienumerablet-int-arity-and-generic-type-definitions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<T, int>> Iterate()
        {
            foreach (KeyValuePair<T, int> kvp in counts) yield return kvp;
        }
    }
