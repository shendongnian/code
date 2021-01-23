      public void RunTest()
      {
         for (int n = 1; n <= 4; n++)
         {
            object o = F(n);
            if (o is int)
               Console.WriteLine("Type = integer");
            else if (o is bool)
               Console.WriteLine("Type = bool");
            else if (o is string)
               Console.WriteLine("Type = string");
            else if (o is float[,])
               Console.WriteLine("Type = matrix");
         }
         Console.ReadLine();
      }
      private object F(int n)
      {
         
         if (n == 1)
            return 42;
         if (n == 2)
            return true;
         if (n == 3)
            return "42";
         if (n >= 4)
         {
            float[,] matrix = new float[n, n];
            for (int i = 0; i < n; i++)
               for (int j = 0; j < n; j++)
                  matrix[i, j] = 42f;
            return matrix;
         }
         return null;
      }
