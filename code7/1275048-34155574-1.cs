    namespace Exercise_4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] userVal = new int[8];
               
            for (int count = 0; count < userVal.Length; count++)
            {
                if (userVal[count] <= 10)
                {
                    Console.WriteLine("Please enter Number");
                    userVal[count] = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("ERROR, Number too BIG!");
                }
            }
            foreach (var cnt in userVal)
            {
                Console.WriteLine(new String('*', cnt));
            }
            Console.ReadKey();
        }
     }
     }
