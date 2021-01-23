    class Program
        {
            public static void update(string [] array)
            {
                string [] newArray = new string [2]; //Local variable
                newArray[0] = "myself";
                newArray[1] = "version2";
            }
            static void Main(string[] args)
            {
                string[] array = new string[2]; //Local variable again
                array[0] = "myself";
                array[1] = "version1";
                Console.WriteLine("{0} {1}", array[0], array[1]);
                update(array);
                Console.WriteLine("{0} {1}", array[0], array[1]);
                Console.ReadLine();
            }
        }
