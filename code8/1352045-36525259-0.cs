    class Program
    {
        
        static int examplevariable;
        static void Main(string[] args)
        {
            examplevariable = Convert.ToInt32(Console.ReadLine ());
            Thread t = new Thread(secondthread);
            t.Start();
        }
        static void secondthread()
        {
            Console.WriteLine(+examplevariable);
        }
