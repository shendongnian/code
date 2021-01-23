    namespace myExtension
    {
    	public static class myMath
        {
            public static double myRoundOff(this double input)
            {
                double Output;
        
                double  AfterPoint = input - Math.Truncate(input);
                double  BeforePoint = input - AfterPoint;
        
                if ((Decimal)AfterPoint == Decimal.Zero && (Decimal)BeforePoint == Decimal.Zero)
                    Output = 0;
        
                else if ((Decimal)AfterPoint != Decimal.Zero && (Decimal)BeforePoint == Decimal.Zero)
                    Output = AfterPoint;
        
                else if ((Decimal)AfterPoint == Decimal.Zero && (Decimal)BeforePoint != Decimal.Zero)
                    Output = BeforePoint;
        
                else
                    Output = AfterPoint + BeforePoint;
        
                return Output;
            }
        }
    }
