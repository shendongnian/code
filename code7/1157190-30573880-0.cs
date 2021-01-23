    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                System.Diagnostics.Process[] procArray;
                procArray = System.Diagnostics.Process.GetProcesses();
                String[,] arr = new String[300,2];
                String max, maxi;
                int k;
                for (k = 0; k < procArray.Length; k++)
                {
                    arr[k, 0] = procArray[k].ProcessName;
                    arr[k, 1] = (procArray[k].Threads.Count).ToString();
                }
    
                for (int i = 0; i < procArray.Length; i++)
                 {
                     for (int j = i; j < procArray.Length; j++)
                      {
                         if (int.Parse(arr[i, 1]) < int.Parse(arr[j, 1]))
                          {
                            max = arr[j, 0];
                            arr[j, 0] = arr[i, 0];
                            arr[i, 0] = max;
                            maxi = arr[j, 1];
                            arr[j, 1] = arr[i, 1];
                            arr[i, 1] = maxi;
                          }
                      }
    
                }
                for (int i = 0; i < procArray.Length; i++)
                {
                   Console.WriteLine("{0} {1}", arr[i, 0], arr[i, 1]);
     
                }                        
    
            }                          
            
        }    
    }
