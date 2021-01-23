      public void RunTest()
      {
         for (int n = 1; n <= 4; n++)
         {
            object o = F(n);
            if (o is int)
               Console.WriteLine("Type = integer, value = " + (int)o);
            else if (o is bool)
               Console.WriteLine("Type = bool, value = " + (bool)o);
            else if (o is string)
               Console.WriteLine("Type = string, value = " + (string)o);
            else if (o is float[,])
            {
               Console.WriteLine("Type = matrix");
               float[,] matrix = (float[,])o;
               // Do something with matrix?
            }
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
            return "forty two";
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
