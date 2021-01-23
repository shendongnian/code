    using System.Linq;
    
    public static bool test(int[] numberArray, int find) 
    { 
                bool s = false;
                numberArray.ToList().ForEach(x => { if (x == find) s = true; }); 
                return s;
    }
