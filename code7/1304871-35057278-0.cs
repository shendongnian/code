    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ReadCreaditCard
    {
        class Program
        {
            static void Main(string[] args)
            {
                //ask for input file path.
                Console.WriteLine("Please Enter the input file path:");
                //@"C:\Users\NIRBHAY\Document\Store Credit-small.txt";
                string path = Console.ReadLine();
    
                //validate the file path.
                while (!File.Exists(path))
                {
                    Console.WriteLine("Please Enter a valid file path:");
                    path = Console.ReadLine();
                }
    
                //open the file to read the data.
                using (StreamReader tr = new StreamReader(path))
                {
                    //read the no of cases.
                    string noOfCases = tr.ReadLine();
                    int caseCounter = 0;
    
                    //validate if first line of input file is valid numeric value.
                    while (!int.TryParse(noOfCases, out caseCounter))
                    {
                        Console.WriteLine("First line of input file is not a numeric value.");
                        Console.WriteLine("Please enter a numeric value:");
                        noOfCases = Console.ReadLine();
                    }
    
                    int caseNo = 1;
                    //read all the lines of data and show it in reverse order.
                    while (caseCounter-- > 0)
                    {
                        #region Read credit value
                        string creditStr = tr.ReadLine();
                        if (creditStr == null)
                        {
                            Console.WriteLine("Invalid input file.");
                            break;
                        }
                        int creditValue = 0;
                        if (!int.TryParse(creditStr, out creditValue))
                        {
                            Console.WriteLine("Invalid input file.");
                            break;
                        }
                        #endregion
    
                        #region Read items count
                        string itemsCountStr = tr.ReadLine();
                        if (itemsCountStr == null)
                        {
                            Console.WriteLine("Invalid input file.");
                            break;
                        }
    
                        int itemsCount = 0;
                        if (!int.TryParse(itemsCountStr, out itemsCount))
                        {
                            Console.WriteLine("Invalid input file.");
                            break;
                        }
                        #endregion
    
                        string itemsPriceStr = tr.ReadLine();
                        if (itemsPriceStr == null)
                        {
                            Console.WriteLine("Invalid input file.");
                            break;
                        }
                        string[] arrayOfCosts = itemsPriceStr.Split(' ');
                        PrintItems(caseNo, creditValue, itemsCount, arrayOfCosts);
                        caseNo++;
                    }
                }
                Console.WriteLine("\n \n Press any key to exit :)");
                Console.ReadKey();
            }
    
            /// <summary>
            /// Prints the indexes of selected items.
            /// </summary>
            /// <param name="caseNo"></param>
            /// <param name="creditValue"></param>
            /// <param name="itemsCount"></param>
            /// <param name="arrayOfCosts"></param>
            private static void PrintItems(int caseNo, int creditValue, int itemsCount, string[] arrayOfCosts)
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    int firstItemCost = int.Parse(arrayOfCosts[i]);
                    for (int j = i + 1; j < itemsCount; j++)
                    {
                        int secondItemCost = int.Parse(arrayOfCosts[j]);
                        if (firstItemCost + secondItemCost == creditValue)
                        {
                            Console.WriteLine("Case#{0}: {1}, {2}", caseNo, i, j);
                            return;
                        }
                    }
                }
            }
        }
    }
