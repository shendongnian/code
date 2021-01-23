    namespace SequenceCheck
    {
        using System;
        public class Program
        {
            public static void Main()
            {
                int[] myArr1 = new int[] { 1, 1, 2, 3, 3};
                int[] myArr2 = new int[] { 1, 1, 3 };
                int[] myArr3 = new int[] { 1, 1, 1, 2, 3, 4, 5, 6, 1 };
    
                // Printing to console True & False respectively.
                Console.WriteLine(Seq_Check(myArr1, 3));
                Console.WriteLine(Seq_Check(myArr2, 2));
                Console.WriteLine(Seq_Check(myArr3, 6));
    
            }
            public static bool Seq_Check(int[] A, int k)
            {
                // TODO Check for corner cases!
    
                // Let's at first sort the numbers
                Array.Sort(A);
    
                int start = 1, end = k;
                // If the first element is not equal to start, something wrong with sequence
                if (A[0] != start) return false;
    
                // If we here it means we checked 1, let go further
                int expected = start + 1;
                int currUnique = A[0];
    
                for (int i = 1; i < A.Length; i++)
                {
                    // Is it new unique number?
                    if (A[i] != A[i - 1])
                    {
                        currUnique = A[i];
                        // Compare with expected and check is there any other numbers?
                        if (currUnique != expected || expected > end)
                            return false;
                        expected++;
                    }
    
                }
                return true;
            }
        }
    }
 
