    using System;
    
    namespace LinqSequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                var arr1 = new int[]
                {
                    1,1,2,1,1,2,2,2,3,3,3,2,4,4,4,4
                };
    
                var newArr1 = SequenceReplace(arr1);
                Console.WriteLine(String.Join(",",newArr1));
                //OUT: 1,1,1,1,1,2,2,2,3,3,3,3,4,4,4,4
    
                var arr2 = new int[]
                {
                    1,1,2,2,2,1,2,3,3,3,2,4,4,4,5,5,4,4
                };
                var newArr2 = SequenceReplace(arr2);
                Console.WriteLine(String.Join(",",newArr2));
                //OUT: 1,1,2,2,2,2,2,3,3,3,3,4,4,4,5,5,4,4
            }
            static int[] SequenceReplace(int[] arr) 
            { 
                int length = arr.Length;
                if (length == 2) return new int[] { arr[0], arr[0] };
                else if (length < 2) return arr;
                var newArr = new int[length];
                newArr[0] = arr[0];
                int previous = 0, next = 2;
    
                for (int i = 1; i < length; i++)
                {
                    if ((next < length &&
                        newArr[previous] != arr[i] && 
                        arr[next] != arr[i]) ||
                        next >= length)
                    {
                        newArr[i] = arr[previous];
                    }
                    else
                    {
                        newArr[i] = arr[i];
                    }
                    previous++;
                    next++;
                }
                return newArr;
            }
        }
    }
