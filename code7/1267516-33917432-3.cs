    public class Program
    {
        public static bool LeftIsGreaterThanRightSide(UInt64 leftSide, int leftSidefactCount, UInt64 rightSide)
        {
            try
            {
                checked
                {
                    UInt64 input2 = leftSide;
                    int factCount = leftSidefactCount;
                    UInt64 result = 1;
                    for (Int64 j = 0; j < factCount; j++)
                    {
                        UInt64 num = input2;
                        for (UInt64 x = num; x > 0; x--)
                        {
                            result = result * x;
                        }
                    }
                    // None of the operand are great or equal than UInt64
                    return result > rightSide; 
                }
            }
            catch (OverflowException)
            {
                // leftSide overflowed, rightSide is a representable UInt64 so leftSide > rightSide ; 
                return true; 
            }
        }
        
        static void Main()
        {
            String input1 = Console.ReadLine();
            String input2 = Console.ReadLine();
            int fact1Count = input1.Count(c => c == '!');
            int fact2Count = input2.Count(c => c == '!');
            UInt64 x = Convert.ToUInt64(input1.Replace("!", String.Empty).Trim());
            UInt64 y = Convert.ToUInt64(input2.Replace("!", String.Empty).Trim());
            
            if (fact1Count > fact2Count)
            {
                fact1Count = fact1Count - fact2Count;
                Console.WriteLine(LeftIsGreaterThanRightSide(x, fact1Count, y) ? "x > y" : "x <= y");
            }
            else
            {
                fact2Count = fact2Count - fact1Count;
                Console.WriteLine(LeftIsGreaterThanRightSide(y, fact2Count, x) ? "y > x" : "y <= x");
            }
            
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
        
    }
