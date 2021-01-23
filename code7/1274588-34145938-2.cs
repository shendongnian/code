        public int Partition(int[] inputArray, int low, int high)
        {
            int pivot = inputArray[high];
            int loopVariable1 = low;
            int loopVariable2 = high;
            while (true)
            {
                while (inputArray[loopVariable2] > pivot) loopVariable2--;
                while (inputArray[loopVariable1] < pivot) loopVariable1++;
                if (loopVariable1 < loopVariable2)
                {
                    Swap(ref inputArray[loopVariable1], ref inputArray[loopVariable2]);
                    for (int loopVariable = low; loopVariable <= high; loopVariable++)
                    {
                        Console.Write(inputArray[loopVariable] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int loopVariable = low; loopVariable <= high; loopVariable++)
                    {
                        Console.Write(inputArray[loopVariable] + " ");
                    }
                    Console.WriteLine();
                    return loopVariable2 - 1;
                }
            }
        }
