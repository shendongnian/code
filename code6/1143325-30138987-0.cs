    Random rand = new Random();  // Only one instance of Random.
    public static char GetRandomDigit()
    {
        string digits = "0123456789";
        int pick = rand.Next(0, digits.Length - 1);
        return digits[pick];
    }
