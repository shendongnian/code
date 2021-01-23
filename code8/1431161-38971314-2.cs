       public static void Main(string[] args)
       {
           int num;
           // This loop ends only when user enters proper integer number
           do
           {
              Console.Clear();
              Console.Write("Please enter some integer number: ");
           } while(!int.TryParse(Console.ReadLine(), out num));                      
       }
