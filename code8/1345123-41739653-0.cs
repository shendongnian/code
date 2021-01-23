            Console.WriteLine("Define Array Size");
            int size = Convert.ToInt32(Console.ReadLine());
            float reference = 0;
            int[] newArray = new int[size];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = Convert.ToInt32(Console.ReadLine());
                reference = reference + newArray[i];
            }
            float Median = reference / newArray.Length;
            Console.WriteLine("The Median is ="+Median);
        }
