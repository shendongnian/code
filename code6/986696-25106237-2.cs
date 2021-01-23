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
            var nums = input.ToList();         
            var repeats = unusedNums.Length;
            
            while (repeats > 0)
            {
                var index_first = rnd.Next(0, nums.Length);
                var index_second = rnd.Next(0, nums.Length);
                
                var temp = nums[index_first];
                nums[index_first] = nums[index_second];
                nums[index_second] = temp;
               
                repeats -= 1;
            }
            
            return new ReadOnlyCollection(nums);
        }
        
        
        public static T[] GetReorderedElementsAsArray<T>(this T[] input)
        {
            return GetRandomElements(input).ToArray();
        }
    }
