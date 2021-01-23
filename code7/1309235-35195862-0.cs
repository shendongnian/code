    class Program
        {
            static void Main(string[] args)
            {
                var A = new bool[] { true, true, false, true };
                var A1 = new bool[] { false, true, false, true };
                var A2 = new bool[] { false, true, false, false };
    
                var B = new bool[] { true, true, false, true };
                var B1 = new bool[] { false, false, false, true };
                var B2 = new bool[] { false, true, false, false };
    
                Console.WriteLine(AtLeastOneColumnIsTrue(A, A1, A2));
                Console.WriteLine(AtLeastOneColumnIsTrue(B, B1, B2));
    
                Console.ReadLine();
            }
    
            public static bool AtLeastOneColumnIsTrue(params bool[][] boolArrays)
            {
                for (int column = 0; column < boolArrays[0].Length; column++)
                {
                    var columnIsAllTrue = true;
    
                    for (int boolArray = 0; boolArray < boolArrays.Length && columnIsAllTrue; boolArray++)
                    {
                        columnIsAllTrue = columnIsAllTrue && boolArrays[boolArray][column];
                    }
    
                    if (columnIsAllTrue)
                    {
                        return true;
                    }
                }
    
                return false;
            }
        }
