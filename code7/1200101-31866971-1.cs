    public class Exercise
    {
        public static int Min(int[] numbers)
        {
            int m = numbers[0];
            // Start at index 1, not 0. m can never be greater than numbers[0].
            for (int i = 1; i < numbers.Length; i++)
            {
                if (m > numbers[i])
                {
                    m = numbers[i];
                    //return m; // This returns at the first number smaller than numbers[0].
                }
            }
            return m; // return the final result here. `if` statement may never get executed.
            //but the method must return `m` anyway as a result
        }
        public static int Max(int[] numbers)
        {
            int m = numbers[0];
            // Start at index 1, not 0. m can never be less than numbers[0].
            for (int i = 1; i < numbers.Length; i++)
            {
                if (m < numbers[i])
                {
                    m = numbers[i];
                    //return m; // This returns at the first number larger than numbers[0].
                }
            }
            return m; // return the final result here. `if` statement may never get executed.
            //but the method must return `m` anyway as a result
        }
        public static void Main() // Main method should not return value
        {
            int[] nbrs = new int[10];
            Random rnd = new Random();
            // dont use `foreach` on array when you want to set values to that array.
            // also `for` has a counter itself. remove the x and put it in `for` statement.
            for (int x = 0; x < nbrs.Length; x++)
            {
                int gen = rnd.Next(1, 501);
                nbrs[x] = gen;
                Console.WriteLine(nbrs[x] + ", ");
            }
            //Exercise exo = new Exercise();
            // you dont have to create a new instance of the current class.
            // just use the methods directly but make them static in order to access it.
            Console.WriteLine("The minimum of the array is {0}", Min(nbrs));
            Console.WriteLine("The maximum of the array is {0}", Max(nbrs));
        }
    }
