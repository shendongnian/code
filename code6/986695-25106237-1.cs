    public static class ArrayExtensions
    {
        private static Lazy<Random> random = new Lazy<Random>(() => new Random());
        
        public static IEnumerable<T> GetReorderedElements<T>(this T[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
        
            var rnd = random.Value;            
            var unusedNums = input.ToList();         
           
            while (unusedNums.Count > 0)
            {
                var index = rnd.Next(0, unusedNums.Length);
                var elem = unusedNums[index];
                unusedNums.RemoveAt(index);
                 
                yield return elem;
            }
        }
            
        public static T[] GetReorderedElementsAsArray<T>(this T[] input)
        {
            return GetReorderedElements(input).ToArray();
        }
    }
