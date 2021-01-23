       public static int EnterNumber()
       {
           Console.Clear();
           Console.Write("Please enter some integer number: ");
           // if number is successfully parsed return number else run method again
           return int.TryParse(Console.ReadLine(), out num)?
                      num : EnterNumber();
       }
       public static void Main(string[] args)
       {
           int num = EnterNumber();
       }
