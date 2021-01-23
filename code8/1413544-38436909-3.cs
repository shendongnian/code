    public static bool IsArmstrong(string numValue)
    {
            long n;
            if (!long.TryParse(numValue, out n))
            {
                throw new Exception($"{numValue} not a number");
            }
            long c = 0, a;
            long temp = n;
            while (n > 0)
            {
                a = n % 10;
                n = n / 10;
                c = c + (int)Math.Pow(a,numValue.Length);
            }
            if (temp == c)
                return true;
            else
                return false;
    }
