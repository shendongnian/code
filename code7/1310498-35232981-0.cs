    public static string getAplha(int number = 65)
    {
        if (number == 90)
        {
            return "" + (char)number;
        }
        return (char)number + getAplha(number + 1);
    }
