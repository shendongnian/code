       public static int EnterNumber()
       {
           Console.Clear();
           Console.Write("Please enter some integer number: ");
           return int.TryParse(Console.ReadLine(), out num)?
                      num : EnterNumber();
       }
       public static void Main(string[] args)
       {
           int num = EnterNumber();
       }
