     static int[] GenerateNumbers()
     {
         int[] num = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         return GenerateNumbers(); //Here is where the problem happens
     }
