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
                    // None of the result are greater than UInt64, compare it as usual
                    return result > rightSide; 
                }
            }
            catch (OverflowException)
            {
                // leftSide overflowed, rightSide is a representable UInt64 so leftSide > rightSide ; 
                return true; 
            }
        }
