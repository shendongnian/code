        static void Main(string[] args)
    {
        int num = 382;
        int output = 0;
        char[] nlst = num.ToString().ToCharArray();
        for (int i = 0; i < nlst.Length; i++)
        {
            output += Convert.ToInt32(nlst[i]);
        }
        Console.WriteLine(output);
        Console.ReadLine();
    }
