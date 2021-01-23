    public static bool checkForPrime(int Number)
        {
            for (int a = 2; a <= Number / 2; a++)
            {
                if (Number % a == 0)
                {
                    return false;
                }
            }
            return true;
        } 
