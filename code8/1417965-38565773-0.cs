    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication26
    {
        class Program
        {
            static void Print3DArr(int[][,] arr)
            {
                foreach(var TwoDArr in arr)
                {
                    for (int lineInd = 0; lineInd < TwoDArr.GetLength(0); lineInd++)
                    {
                        for (int elemInd = 0; elemInd < TwoDArr.GetLength(1); elemInd++)
                        {
                            Console.Write(TwoDArr[lineInd, elemInd] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
    
            static void Main(string[] args)
            {
                int[][,] newArray = new int[4][,];
    
                int[][,] waypoints = new int[4][,]
                {
                    new int[,] {{6,3,4,5,6}},
                    new int[,] {{1,3,4,5,6}},
                    new int[,] {{1,4,3,2,1}},
                    new int[,] {{6,3,4,5,6}}
                };
    
                Print3DArr(waypoints);
    
                for (int TwoDArrIndex = 0; TwoDArrIndex < waypoints.Length; TwoDArrIndex++)
                {
                    newArray[TwoDArrIndex] = new int[waypoints[TwoDArrIndex].GetLength(0), 2];
    
                    for (int LineIn2DArr = 0; LineIn2DArr < waypoints[TwoDArrIndex].GetLength(0); LineIn2DArr++)
                    {
                        newArray[TwoDArrIndex][LineIn2DArr, 0] = waypoints[TwoDArrIndex][LineIn2DArr, 1];
                        newArray[TwoDArrIndex][LineIn2DArr, 1] = waypoints[TwoDArrIndex][LineIn2DArr, 3];
                    }
                }
    
                Print3DArr(newArray);
                Console.ReadKey();
            }
        }
    }
