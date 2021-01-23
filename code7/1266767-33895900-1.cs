    static void Main(string[] args)
    {
        int[,] array = new int[10, 10];
                
        for(int i = 0; i < array.Length / 10; i++)
        {
            array[i, 0] = 1;
            if(i == 1)
            {
                array[i, 1] = 2;
            }
        }
    }
    
