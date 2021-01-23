    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Zumba1
    {
        class Zumba
        {
            static void Main(string[] args)
            { //Recreated the data in the table for the zumba section, added each row, and each column. Worked on formatting.
                string[,] schedule = new string[8, 6] { { "\t\t1:00", "3:00", "5:00", "7:00", "TOTAL", "", },
                                     {"Monday", "\t12", "10", "17", "22", "$244",   },
                                     {"Tuesday", "\t11", "13", "17", "22", "$252",},
                                     {"Wednesday", "12", "10", "22", "22", "$264",},
                                     {"Thursday", "9", "14", "17", "22", "$248",},
                                     {"Friday", "\t12", "10", "21", "12", "$220",},
                                     {"Saturday", "12", "10", "5", "10", "$148"},
                                     {" ", " ", " ", " ", " ","\t$1376",}};
                //Nested for loops to print in a table-style format.
                for (int i = 0; i < schedule.GetLength(0); i++)
    
                {
                    for (int j = 0; j < schedule.GetLength(1); j++)
                    {
                        Console.Write(schedule[i, j] + "\t");
                    }
                    {
                        Console.WriteLine(i.ToString());
                    }
                    
                }
         Console.ReadLine();
                }
            }
        }
    }
