    public static bool SelfDescribing(string num)
    {
       char[] digit = num.ToArray();
       int bound = digit.Count();
       int arrLength = 0;
       for (int i = 0; digit.Length != 0 && i < bound; i++)
       {
            var count = num.Count(x => x == digit[i]);
            if (count == i)
            {
                arrLength++;
                if (arrLength == bound)
                {
                    return true;
                }
             }          
       }
       return false;
     }
