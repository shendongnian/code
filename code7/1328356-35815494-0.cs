    using System;
    namespace Test
    {
      class Program
      {
        static void Main(string[] args)
        {
          var mClass = new myClass();
          Console.WriteLine("Before Optimization");
          mClass.PrintParameters();
          mClass.Optimize();
          Console.WriteLine("After Optimization");
          mClass.PrintParameters();
          Console.ReadKey();
        }
      }
      class myClass
      {
        int nVariables;
        public double[] parameters; //length = X * nVarialbes
        public int[] A; //length = X
        public int[] B; //length = X
        public int[] C; //length = X
        public myClass()
        {
          parameters = new[] {0.0, 1.1, 2.2, 3.3, 4.4, 5.5};
          A = new[] {0, 1};
          B = new[] {2, 3};
          C = new[] {4, 5};
        }
        public void Optimize()
        {
          //A's need to have b's paramaters added to them
          parameters[A[0]] += parameters[B[0]];
          parameters[A[1]] += parameters[B[1]];
          //C's paramaters get their sign inverted
          parameters[C[0]] *= -1;
          parameters[C[1]] *= -1;
        }
        public void PrintParameters()
        {
          for(int index =0; index < parameters.Length; ++ index)
          {
            Console.WriteLine("[{0}] = {1}", index, parameters[index]);
          }
        }
      }
    }
