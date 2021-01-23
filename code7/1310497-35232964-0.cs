    public static void getAplha(int number=65)
    {
        Console.WriteLine(Convert.ToChar(number));
        if (number==90)
        {
            return;
        }
        
        getAplha(number + 1);
    }
