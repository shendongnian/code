    public static class AwesomeSign
    {
     public static bool IsPositive(int number)
     {
        return number > 0;
     }
     public static bool IsNegative(int number)
     {
        return number < 0;
     }
    public static bool IsZero(this int number)
    {
        return number == 0;
    }
     public static bool IsAwesome(int number)
     {
        return IsNegative(number) && IsPositive(number) && IsZero(number);
     }
     public static bool printSign(int number)
     {
       if(IsPositive(number))
       {
         Console.WriteLine("+" + number);
       }
     }
    }
