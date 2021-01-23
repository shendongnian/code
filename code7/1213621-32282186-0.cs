    public int[] ArrayAndReverse(int Number)
    {
        int[] data = new int[Number];
        int index = 
        for (int x = Number; x > 0; x--)
        {
            index = Convert.ToInt32(index + x);
            Console.Write(x);
        }
        return data.Reverse().ToArray();
    }
