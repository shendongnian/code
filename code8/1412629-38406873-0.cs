    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace DuplicateHandsOn
    {
        class Program
        {
            static void Main(string[] args)
            {
                //create an array of type int
                int[] aList;
                //create a counter to keep track of how many numbers have been entered
                int counter = 0;
                //create a boolean flag to let us know whether the number can be added or not
                bool isDuplicate = false;
                //ask the user how many numbers they will be entering
                Console.WriteLine("How many numbers will you enter?");
                int arraySize = Convert.ToInt32(Console.ReadLine());
                //initialize the array with that amount
                aList = new int[arraySize];
                while (counter < arraySize)
                {
                    //prompt the user for the first number
                    Console.Write("Enter Number: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    // FIX: This should be && instead of || to test if
                    // both of these conditions are true to match
                    // the comment
                    //check if the number is between 10 and 100
                    if (num1 >= 10 && num1 <= 100)
                    {
                        //check if this number exists in the array
                        for (int i = 0; i < aList.Length; i++)
                        {
                            if (aList[i] == num1)
                            {
                                //this number exists in the list
                                Console.WriteLine("{0} has already been entered", aList[i]);
                                isDuplicate = true;
                            }
                        }
                        // FIX: This should only happen if the number
                        // is not a duplicate
                        if (!isDuplicate)
                        {
                            //put the number into the array
                            aList[counter] = num1;
                            // FIX: Move this line into here to only increment 
                            // the counter if th enumber is placed in the array
                            //increment the counter
                            counter++;
                        }
                        //print the array
                        for (int j = 0; j < aList.Length; j++)
                        {
                            //exclude zeros
                            if (aList[j] == 0)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine(aList[j]);
                            }
                        }
                        //reset the flag
                        isDuplicate = false;
                    }
                    else
                    {
                        Console.WriteLine("Numbers should be between 10 and 100");
                    }
                }
    #if DEBUG
                Console.ReadKey();
    #endif
            }
        }
    }
