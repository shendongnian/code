    int[] test = new int[10];
    int count = 0;
         try
          {
             for (; ; )
             {
              count++;
              test[count].ToString();
             }
          }
    catch (IndexOutOfRangeException ex)
      {
      }
    Console.Write(count);
    Console.ReadKey();
