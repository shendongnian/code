    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ProgrammingBasics
    {
        class Exercise
        {
            static void Main()
            {
                PrintArray(arr);
                SubarrayWithSum();
            }
            //--------------------------------------------------------------------
            /*
                Data members.
            */
            // targer array
            static int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
            // target sum
            static int sum = 14;
            //--------------------------------------------------------------------
            /*
                Method: IsSubarrayWithSum(arr, sum);
                It returns a bool value that indicates
                whether there is a subarray within arr
                with elements that sum up to specific value.
            */
            static void SubarrayWithSum()
            {
                int depth = 0;
                int endIndex = arr.Length - 1;
                CheckAllCombinations(new int[arr.Length], depth);
            }
            //--------------------------------------------------------------------
            /*
                Method: CheckAllCombinations(subarray, sum);
            */
            static void CheckAllCombinations(int[] subarray, int depth)
            {
                //Console.ReadKey();
                for (int i = depth; i < arr.Length; i++)
                {
                    subarray[depth] = arr[i];
                    Console.WriteLine("depth = {0}, i = {1}, array = '{2}'  ", depth, i, string.Join(",",subarray.Select(x => x.ToString()).ToArray()));
                    int currentSum = subarray.Take(depth + 1).Sum();
                    if (currentSum == sum)
                    {
                        Console.Write("S = {0} -> yes", sum);
                        PrintSubArray(subarray);
                    }
                    //PrintArray(subarray);
                    //Console.ReadKey();
                    if (currentSum < sum)
                    {
                        CheckAllCombinations(subArray, i + 1);
                    }
                }
            }
            //--------------------------------------------------------------------
            /*
                Method: IsWantedSum(int[] arr)
            */
            //--------------------------------------------------------------------
            /*
                Method: PrintArray();
            */
            static void PrintArray(int[] subarray)
            {
                Console.Write("{");
                for (int i = 0; i < subarray.Length; i++)
                {
                    Console.Write(subarray[i]);
                    if (i < subarray.Length - 1) Console.Write(", ");
                }
                Console.WriteLine("}");
            }
            //--------------------------------------------------------------------
            /*
                Method: PrintSubArray();
            */
            static void PrintSubArray(int[] subarray)
            {
                Console.Write("(");
                for (int i = 0; i < subarray.Length; i++)
                {
                    if (subarray[i] != 0) Console.Write(subarray[i]);
                    if (subarray[i] != 0 && i < subarray.Length - 1) Console.Write(" + ");
                }
                Console.WriteLine(" = {0})", sum);
            }
        }
    }
