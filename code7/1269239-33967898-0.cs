            //using System.Collections.Generic;
            //using System.Linq;
            Console.Clear();
            List<String> Clean = new List<string>() { "1:1", "2:1", "3:1", "4:1", "5:2", "6:1", "6:2", "6:60", "7:1", "8:1", "9:2", "10:10" };
            for (int i = 0; i < 3; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                int index = rnd.Next(0, Clean.Count);
                if (Clean[index].Contains("*"))
                {//Already has noise.
                    i--;
                }
                else
                {//Make some noise.
                    Clean[index] = Clean[index] + "**" + i.ToString() + "* *";
                }
            }
            Clean.ForEach(var => Console.WriteLine(var));
            Console.WriteLine();
            Console.ReadLine();
