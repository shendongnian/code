    public static class EnumerableExtensions {
       public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T element) {
            foreach (var e in source) {
                yield return e; 
            }
            yield return element;
        }
        
        public static IEnumerable<T> Concat<T>(this T source, IEnumerable<T> element) {
            yield return source; 
            foreach (var e in element) {
                yield return e;
            }
            
        }
    }
    
    class Program
    {
        static void Main()
        {
            List<int> ints = new List<int> {1, 2, 3}; 
            var startingInt = 0; 
            
            foreach (var i in startingInt.Concat(ints).Concat(4)) {
                Console.WriteLine(i);
            }
        }
    }
