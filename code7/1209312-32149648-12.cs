    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ArraySquareRotation
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] arr = new int[]
                {
                    1, 2, 3, 4, 5, 3,
                    12, 13, 14, 5, 6, 1,
                    11, 15, 16, 6, 7, 22,
                    10, 9, 8, 7, 8, 30,
                    11, 15, 16, 6, 7, 22,
                    1, 2, 3, 4, 5, 3
                };
    
                
                // detect array size
                int size = arr.Length;
    
                // calculate the side length of the array (in terms of index)
                int sideLength = BruteForceSquareDimensions(size);
    
                // find the start of the last side of the square
                int lastRowStartIndex = size - sideLength;
    
                // a placeholder for us to generate a shifted array
                int[] arrRotated = new int[size];
    
    
                Console.WriteLine("Detected square with side length {0}", sideLength);
                Console.WriteLine();
    
                for (int i = 1; i <= size; i++)
                {
                    // side rotation
                    if ((i % sideLength) == 0 && i != size)
                    {
                        // is multiple of
                        // right hand side, shift down
                        arrRotated[i + sideLength - 1] = arr[i - 1];
    
                        // left hand side, shift up
                        arrRotated[i + sideLength - (sideLength * 2)] = arr[i];
                    } else if (i < sideLength)
                    {
                        int lastRowIndex = sideLength * (sideLength - 1);
    
                        // first row, shift right
                        arrRotated[i] = arr[i - 1];
    
                        // last row, shit left
                        arrRotated[i + lastRowIndex - 1] = arr[i + lastRowStartIndex];
                    } else if(i < lastRowStartIndex)
                    {
                        // the inner square (this case may need some work)
                        arrRotated[i - 1] = arr[i - 1];
                    }
    
                }            
    
                Console.WriteLine("Printing original array");
                Console.WriteLine("======================");
                PrintSquareArray(arr);
    
                Console.WriteLine();
    
    
                Console.WriteLine("Printing Shifted array");
                Console.WriteLine("======================");
                PrintSquareArray(arrRotated);
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
    
            }
    
            /// <summary>
            /// there is definately a better way.
            /// </summary>
            /// <param name="size"></param>
            /// <returns></returns>
            static int BruteForceSquareDimensions(int size)
            {
    
                int sideLength = 0;
    
                for (int i = 1; i < size; i++)
                {
                    if ((i * i) == size)
                    {
                        sideLength = i;
                    }
                }
    
                return sideLength;
            }
    
            /// <summary>
            /// This method just prints the array in the desired readable format
            /// </summary>
            /// <param name="arr"></param>
            static void PrintSquareArray(int[] arr)
            {
                int size = arr.Length;
                int sideLength = BruteForceSquareDimensions(size);
    
                for(int i = 1; i <= size; i++)
                {
                    if ((i % sideLength) == 0)
                    {
                        Console.WriteLine(arr[i - 1]);
                    }
                    else
                    {
                        Console.Write(arr[i - 1] + "\t");
                    }
                }
            }
        }
    }
