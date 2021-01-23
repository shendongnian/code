    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    namespace ConsoleApp1
    {
    class ArrayLeftRotationSolver
    {
        TextWriter mTextWriter;
        public ArrayLeftRotationSolver()
        {
             mTextWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            
        }
        public void Solve()
        {
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
            ;
            int[] result = rotLeft(a, d);
            mTextWriter.WriteLine(string.Join(" ", result));
            mTextWriter.Flush();
            mTextWriter.Close();
        }
        private int[] rotLeft(int[] arr, int shift)
        {
            int n = arr.Length;
            shift %= n;
            int[] vec = new int[n];
            for (int i = 0; i < n; i++)
            {
                vec[(n + i - shift) % n] = arr[i];
            }
            return vec;
        }
        static void Main(string[] args)
        {
             ArrayLeftRotationSolver solver = new ArrayLeftRotationSolver();
             solver.Solve();
        }
    }
}
