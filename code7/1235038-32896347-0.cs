           int[] num = new int[] { 1, 4, 7, 6, 9, 3, 0, 8, 5, 2 };
            //int comparisons = 0;
            int loopSize = num.Length - 1;
            for (int i = 0; i <= loopSize; i++) //Outer loop
            {
                for (int j = 0; j < loopSize - i; j++) // Inner loop
                {
                    //comparisons++;
                    if (num[j] > num[j + 1])
                    {
                        temp = num[j + 1];
                        num[j + 1] = num[j];
                        num[j] = temp;
                    }
                }
            }
            //Displaying the array 
            for (int i = 0; i < num.Length; i++)
                Console.WriteLine(num[i]);
            //Console.WriteLine("comp: {0}", comparisons);
            //Console.ReadKey();
        } 
