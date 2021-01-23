     int[] input = new int[5];
            input[0] = 5;
            input[1] = 40;
            input[2] = 15;
            input[3] = 50;
            input[4] = 25;
            int sum = 0;
            foreach(int i in input)
            {
                sum = sum + i;
            }
            sum = sum / input.Length;
            Console.WriteLine(sum.ToString());
