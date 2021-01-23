    using System;
    
    namespace LinqSequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                var arr = new int[]
                {
                    1,1,2,2,2,1,2,3,3,3,2,4,4,4,5,5,4,4
                };
                var newArr = SequenceReplace(arr);
                Console.WriteLine(String.Join(", ",newArr));
                //OUT: 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 5
            }
            static int[] SequenceReplace(int[] arr) 
            {
                int length = arr.Length;
                var newArr = new int[length];
                int previous = 0;
                
                for (int i = 0; i < length; i++)
                {
                    if (newArr[previous] > arr[i]) 
                    {
                        newArr[i] = newArr[previous];
                    }
                    else
                    {
                        newArr[i] = arr[i];
                    }
                    previous = i;
                }
                return newArr;
            }
        }
    }
