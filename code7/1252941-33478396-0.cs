    static void Main(string[] args)
    {
        Console.WriteLine("A.Settings1.Default.AExeSetting1: {0}", A.Settings1.Default.AExeSetting1);
        A.Settings1.Default.AExeSetting1 += "-";
        Console.ReadLine();
        A.Settings1.Default.Save();
    }
