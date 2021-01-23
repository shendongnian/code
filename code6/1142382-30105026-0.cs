    void Main()
    {
        string[,] options = new string[100,3];
        
        options[3, 1] = "Hi";
        options[5, 0] = "Dan";
        
        var results = 
            options
                .JagIt()
                .Where(i => i.Any(j => j != null))
                .UnjagIt();
                
        results.Dump();
    }
    
    static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> JagIt<T>(this T[,] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
                yield return GetRow(array, i);
        }
        
        public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
        {
            for (var j = 0; j < array.GetLength(1); j++)
                yield return array[rowIndex, j];
        }
        
        public static T[,] UnjagIt<T>(this IEnumerable<IEnumerable<T>> jagged)
        {
            var rows = jagged.Count();
            if (rows == 0) return new T[0, 0];
            
            var columns = jagged.Max(i => i.Count());
            
            var array = new T[rows, columns];
            
            var row = 0;
            var column = 0;
            
            foreach (var r in jagged)
            {
              column = 0;
              
              foreach (var c in r)
              {
                array[row, column++] = c;
              }
              
              row++;
            }
            
            return array;
        }
    }
