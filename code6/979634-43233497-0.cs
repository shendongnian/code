    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;
    namespace CSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n;
                n =Int32.Parse(Console.ReadLine());
                int[] arr = new int[n];
                string[] s = Console.ReadLine().Split(' ');
                for (int i= 0;i< n;i++)
                {
                    arr[i] = Int32.Parse(s[i]);
                }
                Console.WriteLine(n);
                foreach (var item in arr)
                {
                    Console.Write(item+" ");
                }
            }
        }
    }
