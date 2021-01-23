    public static class Extensions
    {
       public static int Multiple(this int a)
       {
           return a * 2;
       }
    }
    public static void Main()
    {
        Console.WriteLine("Entrer un numero");
        int a = int.Parse(Console.ReadLine());
        a = a.Multiple();
        Console.ReadKey();
    }
