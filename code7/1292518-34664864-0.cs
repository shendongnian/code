    static void Main(string[] args)
    {
        int[] input = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Write " + (i + 1) + " number");
            int temp;
            while (!int.TryParse(Console.ReadLine(), out temp)
            {
                Console.WriteLine("Write " + (i + 1) + " number");
            }
            input[i] = temp;
        }
        // at this point you have all 10 numbers written by the user
    }
