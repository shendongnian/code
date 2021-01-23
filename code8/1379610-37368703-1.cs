    using System.Linq;
    
    public static string test(int[] numberArray, int find) 
    { 
                bool s = false;
                numberArray.ToList().ForEach(x => { if (x == find) s = true; }); 
                return s ? "It contains it." : "Can't find it.";
    }
