         int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
         List<int> output = new List<int>();
         int i;
         int y = 0;
         for (i = 0; i < 7; i++)
         {  
          output.Add(input[i]);
          output.Add(input[i] + y);
          y = output.Last();
         }
         
        for (i = 0; i < output.Count; i++)
        {
            Console.Write(output[i]);
        }
