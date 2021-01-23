     public class IntArrayComparer : IEqualityComparer<int[]>
     {    
         public bool Equals(int[] x, int[] y)
         {
             return x.SequenceEqual(y);
         }
    
         public int GetHashCode(int[] obj)
         {
             return base.GetHashCode();
         }
     }
