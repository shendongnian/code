    public static bool IsArmstrong(string numValue)
    {
        int temp;
        if (!int.TryParse(numValue, out temp))
        {
            throw new Exception($"{numValue} not a number");
        }
        int c = 0, a;
        int n = 153;//It is the number to check armstrong  
        temp = n;
        while (n > 0)
        {
            a = n % 10;
            n = n / 10;
            c = c + (a * a * a);
        }
        if (temp == c)
            return true;
        else
            return false;
    }
