     Console.WriteLine("Enter the size of the array");
            int number = int.Parse(Console.ReadLine());
            int[] marks = new int[number];
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("Enter some more numbers", i + 1);
                marks[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("\nData #{0}: {1}\n", i + 1, marks[i]);
            }
