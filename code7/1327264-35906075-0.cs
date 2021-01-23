            // Arr[]
            int n = 10;
            int[] arr = new int[n];
            for (int index = 0; index < n; index++)
            {
                Console.Write("Array[{0}] = ", index);
                arr[index] = int.Parse(Console.ReadLine());
            }
            // Len[]
            int[] len = new int[n];
            for (int index = 0; index < n; index++)
            {
                len[index] = 1;
            }
            // Correct len[]
            for (int indexCount = 1; indexCount < n; indexCount++)
            {
                for (int indexNumber = 0; indexNumber < indexCount; indexNumber++)
                {
                    if (arr[indexCount] > arr[indexNumber] && len[indexCount] < len[indexNumber] + 1)
                    {
                        len[indexCount] = len[indexNumber] + 1;
                    }
                }
            }
            // Print new len[]
            // Just to keep track of numbers
            Console.WriteLine();
            Console.Write("{");
            for (int index = 0; index < n; index++)
            {
                Console.Write(" " + len[index] + " ");
            }
            Console.WriteLine("}");
            // Search for the max number in len[]
            int max = int.MinValue;
            int maxPosition = 0;
            for (int index = 0; index < len.Length; index++)
            {
                if (len[index] > max)
                {
                    max = len[index];
                    maxPosition = index;
                }
            }
            // Create the result in result[]
            int[] result = new int[max];
            int i = (max - 1);
            int maxCount = max;
            for (int index = maxPosition; index >= 0; index--)
            {
                if (len[index] == max)
                {
                    result[i] = arr[index];
                    max--;
                    i--;
                }
            }
            // Print the result[]
            Console.WriteLine();
            Console.Write("{");
            for (int index = 0; index < maxCount; index++)
            {
                Console.Write(" " + result[index] + " ");
            }
            Console.WriteLine("}");
