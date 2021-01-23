        private static int[] getInput()
        {
            int[] array = { 20, 22, 23, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,    1, 1 };
            bool done = false;
            int current = 4;
            while (!done)
            {
                Console.WriteLine("Enter in a number to be added to the array");
                string input = Console.ReadLine();
                array[current] = Convert.ToInt32(input);
                current++;
                if (current==array.Length)
                {
                    done = true;
                }
            }
            return array;
        }
