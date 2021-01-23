    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            /// <summary>
            /// Helper to show array.
            /// </summary>
            /// <param name="mat"></param>
            static void ShowArray(double[,] mat)
            {
                int ubound = mat.GetUpperBound(0);
    
                for (int row = 0; row <= ubound; row++)
                {
                    for (int col = 0; col <= ubound; col++)
                    {
                        Console.Write(string.Format("{0,2} ", mat[col, row]));
                    }
                    Console.WriteLine();
                };
    
                Console.WriteLine();
    
            }
    
            /// <summary>
            /// Get an array without the zeroth row and without a specified column.
            /// </summary>
            /// <param name="mat">The square array to remove items from.</param>
            /// <param name="knockoutCol">The column to eliminate.</param>
            /// <returns>A square array of size one less than the input array.</returns>
            static double[,] SubMatrix(double[,] mat, int knockoutCol)
            {
                if (mat.GetUpperBound(0) != mat.GetUpperBound(1))
                {
                    throw new ArgumentException("Array is not square.");
                }
    
                int ubound = mat.GetUpperBound(0);
                double[,] m = new double[ubound, ubound];
    
                int mCol = 0;
                int mRow = 0;
    
                for (int row = 1; row <= ubound; row++)
                {
                    mCol = 0;
                    for (int col = 0; col <= ubound; col++)
                    {
                        if (col == knockoutCol)
                        {
                            continue;
                        }
                        else
                        {
                            m[mCol, mRow] = mat[col, row];
                            mCol += 1;
                        }
                    }
                    mRow += 1;
    
                };
    
                return m;
            }
    
            static void Main(string[] args)
            {
                int arraySize = 4;
                double[,] mat = new double[arraySize, arraySize];
                int ubound = mat.GetUpperBound(0);
    
                // Initialise array for inspection.
                for (int row = 0; row <= ubound; row++)
                {
                    for (int col = 0; col <= ubound; col++)
                    {
                        mat[col, row] = (arraySize * row) + col;
                    }
                };
    
                ShowArray(mat);
    
                ShowArray(SubMatrix(mat, 0));
                ShowArray(SubMatrix(mat, 1));
                ShowArray(SubMatrix(mat, 2));
    
                Console.ReadLine();
    
            }
        }
    }
    
