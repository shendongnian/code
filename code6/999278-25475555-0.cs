    static void Shuffle(ref ArrayList list)
    {
        Random rng = new Random();
        
        for (int i = list.Count - 1; i >= 0; i--)
        {
            // Note: It's important to only select a number into each index
            // once. Otherwise you'll get bias toward some numbers over others.
            int number = rng.Next(i); // Choose an index to swap here
            Swap(ref list[i], ref list[number]) // Swap it
        }
    }
    static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }
    static void Main(string[] args)
    {
        ArrayList list = new ArrayList();
        for(int i = 1; i <= 49; i++)
        {
            list.Add(i);
        }
        Shuffle(ref list);
        for (int i = 1; i <= 6; i++)
        {
            // Use the shuffled list
        }
    }
